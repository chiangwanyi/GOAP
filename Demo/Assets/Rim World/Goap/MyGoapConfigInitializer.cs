using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Behaviours;

namespace Rim_World.Goap
{
    public class MyGoapConfigInitializer: GoapConfigInitializerBase
    {
        public override void InitConfig(IGoapConfig config)
        {
            config.GoapInjector = this.GetComponent<GoapInjectorBehaviour>();
        }
    }
}
