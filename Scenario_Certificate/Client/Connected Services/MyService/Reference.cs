﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.IMyService")]
    public interface IMyService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyServise/DoWork", ReplyAction="http://tempuri.org/IMyServise/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/Add", ReplyAction="http://tempuri.org/IMyService/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int x, int y);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IMyServiceChannel : MyService.IMyService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class MyServiceClient : System.ServiceModel.ClientBase<MyService.IMyService>, MyService.IMyService
    {
        
        public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync()
        {
            return base.Channel.DoWorkAsync();
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int x, int y)
        {
            return base.Channel.AddAsync(x, y);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
    }
}