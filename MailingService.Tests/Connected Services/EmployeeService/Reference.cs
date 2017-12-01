﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace Tests.EmployeeService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeByUsername", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByUsernameResponse")]
        Core.Employee GetEmployeeByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeByUsername", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByUsernameResponse")]
        System.Threading.Tasks.Task<Core.Employee> GetEmployeeByUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetListOfEmployeesByDepartmentId", ReplyAction="http://tempuri.org/IEmployeeService/GetListOfEmployeesByDepartmentIdResponse")]
        Core.Employee[] GetListOfEmployeesByDepartmentId(int departmentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetListOfEmployeesByDepartmentId", ReplyAction="http://tempuri.org/IEmployeeService/GetListOfEmployeesByDepartmentIdResponse")]
        System.Threading.Tasks.Task<Core.Employee[]> GetListOfEmployeesByDepartmentIdAsync(int departmentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeesByDepartmentId", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeesByDepartmentIdResponse")]
        Core.Employee[] GetEmployeesByDepartmentId(int depId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeesByDepartmentId", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeesByDepartmentIdResponse")]
        System.Threading.Tasks.Task<Core.Employee[]> GetEmployeesByDepartmentIdAsync(int depId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        List<Employee> GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        Task<List<Employee>> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/InsertEmployee", ReplyAction="http://tempuri.org/IEmployeeService/InsertEmployeeResponse")]
        void InsertEmployee(Core.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/InsertEmployee", ReplyAction="http://tempuri.org/IEmployeeService/InsertEmployeeResponse")]
        System.Threading.Tasks.Task InsertEmployeeAsync(Core.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/UpdateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/UpdateEmployeeResponse")]
        void UpdateEmployee(Core.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/UpdateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/UpdateEmployeeResponse")]
        System.Threading.Tasks.Task UpdateEmployeeAsync(Core.Employee employee);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : Tests.EmployeeService.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<Tests.EmployeeService.IEmployeeService>, Tests.EmployeeService.IEmployeeService {
        
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
        
        public Core.Employee[] GetListOfEmployeesByDepartmentId(int departmentId) {
            return base.Channel.GetListOfEmployeesByDepartmentId(departmentId);
        }
        
        public System.Threading.Tasks.Task<Core.Employee[]> GetListOfEmployeesByDepartmentIdAsync(int departmentId) {
            return base.Channel.GetListOfEmployeesByDepartmentIdAsync(departmentId);
        }
        
        public Core.Employee[] GetEmployeesByDepartmentId(int depId) {
            return base.Channel.GetEmployeesByDepartmentId(depId);
        }
        
        public System.Threading.Tasks.Task<Core.Employee[]> GetEmployeesByDepartmentIdAsync(int depId) {
            return base.Channel.GetEmployeesByDepartmentIdAsync(depId);
        }
        
        public List<Employee> GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<List<Employee>> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public void InsertEmployee(Core.Employee employee) {
            base.Channel.InsertEmployee(employee);
        }
        
        public System.Threading.Tasks.Task InsertEmployeeAsync(Core.Employee employee) {
            return base.Channel.InsertEmployeeAsync(employee);
        }
        
        public void UpdateEmployee(Core.Employee employee) {
            base.Channel.UpdateEmployee(employee);
        }
        
        public System.Threading.Tasks.Task UpdateEmployeeAsync(Core.Employee employee) {
            return base.Channel.UpdateEmployeeAsync(employee);
        }
    }
}
