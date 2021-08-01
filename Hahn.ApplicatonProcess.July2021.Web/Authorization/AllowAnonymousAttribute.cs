using System;
namespace Hahn.ApplicatonProcess.July2021.Web.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}