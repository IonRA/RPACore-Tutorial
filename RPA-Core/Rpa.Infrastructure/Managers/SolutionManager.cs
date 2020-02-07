using Services.Rpa.Domain.Models;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Infrastructure.Managers;
using Services.Rpa.Infrastructure.Repositories;
using Services.Rpa.Domain.Interfaces.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Services.Rpa.MetadataDbContext;
namespace Services.Rpa.Infrastructure.Managers
{
    public class SolutionManager: ISolutionManager
    {

        public bool Ok;
        public SolutionManager(ISolutionRepository solutionRepository)
        {
        }

        public async Task Execute(Solution solution)
        {
            
            var orderedComponents = solution.Components.OrderBy(c => c.Position).ToList();
            RpaContext rpaCtxt = new RpaContext();
            OpenAppManager openMan = new OpenAppManager(new OpenAppRepository(rpaCtxt));
            WriteAppManager writeMan = new WriteAppManager(new WriteAppRepository(rpaCtxt));
            SaveAppManager saveMan = new SaveAppManager(new SaveAppRepository(rpaCtxt));
            CloseAppManager closeMan = new CloseAppManager(new CloseAppRepository(rpaCtxt));

            for (int i = 0; i < orderedComponents.Count; ++i)
            {
                var comp = orderedComponents[i];

                if (comp.GetType() == typeof(OpenApp))
                {
                    await openMan.Execute((OpenApp)comp);
                }
                else if (comp.GetType() == typeof(WriteApp))
                {
                    var writeComp = (WriteApp)comp;
                    writeComp.ComponentProcess = openMan.ComponentProcess;
                    await writeMan.Execute(writeComp);
                }
                else if (comp.GetType() == typeof(SaveApp))
                {
                    var saveApp = (SaveApp)comp;
                    saveApp.WindowHandler = writeMan.WindowHandler;
                    await saveMan.Execute(saveApp);
                }
                else if (comp.GetType() == typeof(CloseApp))
                {
                    var closeApp = (CloseApp)comp;
                    closeApp.ComponentProcess = openMan.ComponentProcess;
                    await closeMan.Execute(closeApp);
                    Ok = true;
                }
            }
        }
    }
}
