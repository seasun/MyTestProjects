using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Service.Interface
{
    [ServiceContract(Name = "CalculatorService", Namespace = "http://www.seasun.com/")]
    public interface Icalculator
    {
        //要显式指定“服务操作”
        [OperationContract]
        double Add(double x, double y);
        [OperationContract]
        double Subtract(double x, double y);
        [OperationContract]
        double Multiply(double x, double y);
        [OperationContract]
        double Divide(double x, double y);
    }
}
