namespace PaymentApp.Repository.UnitOfWorkPattern
{
    using PaymentApp.Repository.Interface;
    using System;

    public interface IUnitOfWork: IDisposable
    {
        IPaymentRepository Payment { get; }
        int Complete();
    }
}
