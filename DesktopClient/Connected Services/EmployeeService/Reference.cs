﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopClient.EmployeeService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeByUsername", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByUsernameResponse")]
        Core.Employee GetEmployeeByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeByUsername", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByUsernameResponse")]
        System.Threading.Tasks.Task<Core.Employee> GetEmployeeByUsernameAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : DesktopClient.EmployeeService.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<DesktopClient.EmployeeService.IEmployeeService>, DesktopClient.EmployeeService.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Core.Employee GetEmployeeByUsername(string username) {
            return base.Channel.GetEmployeeByUsername(username);
        }
        
        public System.Threading.Tasks.Task<Core.Employee> GetEmployeeByUsernameAsync(string username) {
            return base.Channel.GetEmployeeByUsernameAsync(username);
        }
    }
}
