using System;
using System.Linq;
using CrashKonijn.Agent.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Goap.Runtime;
using Rim_World.Behaviours;
using Rim_World.GameItems;
using Rim_World.Interfaces;

namespace Rim_World.Actions
{
    [GoapId("CreateItem-e28cdca4-3b39-445e-88cb-91025899174a")]
    public class CreateItemAction<T> : GoapActionBase<CreateItemAction<T>.Data, CreateItemAction<T>.Props>, IInjectable
        where T : ItemBehaviour, ICreatable
    {
        private ItemFactoryBehaviour itemFactory;
        
        public void Inject(GoapInjectorBehaviour injector)
        {
            this.itemFactory = injector.itemFactory;
        }
        
        // This method is called when the action is created
        // This method is optional and can be removed
        public override void Created()
        {
        }

        // This method is called every frame before the action is performed
        // If this method returns false, the action will be stopped
        // This method is optional and can be removed
        public override bool IsValid(IActionReceiver agent, Data data)
        {
            return true;
        }

        // This method is called when the action is started
        // This method is optional and can be removed
        public override void Start(IMonoAgent agent, Data data)
        {
            data.WaitState = ActionRunState.Wait(5f);
        }

        // This method is called once before the action is performed
        // This method is optional and can be removed
        public override void BeforePerform(IMonoAgent agent, Data data)
        {
            for (int i = 0; i < this.Properties.requiredWood; i++)
            {
                var wood = data.AgentInventory.Get<Wood>().FirstOrDefault();
                data.AgentInventory.Remove(wood);
            }
        }

        // This method is called every frame while the action is running
        // This method is required
        public override IActionRunState Perform(IMonoAgent agent, Data data, IActionContext context)
        {
            if (data.WaitState.IsRunning())
            {
                return data.WaitState;
            }
            
            return ActionRunState.Completed;
        }

        // This method is called when the action is completed
        // This method is optional and can be removed
        public override void Complete(IMonoAgent agent, Data data)
        {
            var item = this.itemFactory.Instantiate<T>();
            item.transform.position = agent.transform.position;
        }

        // This method is called when the action is stopped
        // This method is optional and can be removed
        public override void Stop(IMonoAgent agent, Data data)
        {
        }

        // This method is called when the action is completed or stopped
        // This method is optional and can be removed
        public override void End(IMonoAgent agent, Data data)
        {
        }

        [Serializable]
        public class Props : IActionProperties
        {
            public int requiredWood;
        }

        // 某个 Agent 独立的数据
        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public IActionRunState WaitState { get; set; }
            
            [GetComponent]
            public AgentInventoryBehaviour AgentInventory { get; set; }
        }
    }
}