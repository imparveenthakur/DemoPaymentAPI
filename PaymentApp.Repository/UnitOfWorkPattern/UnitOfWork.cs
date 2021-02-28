using System;
using PaymentApp.Entity.DataAccess;
using PaymentApp.Repository.Implementation;
using PaymentApp.Repository.Interface;

namespace PaymentApp.Repository.UnitOfWorkPattern
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly PaymentDBContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="DbContext"/></param>
        public UnitOfWork(PaymentDBContext context)
        {
            _context = context;
        }

        private IPaymentRepository paymentRepository;

        public IPaymentRepository Payment
        {
            get
            {
                if (paymentRepository == null)
                {
                    paymentRepository = new PaymentRepository(_context);
                }
                return paymentRepository;
            }
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        /// <summary>
        /// Defines the disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
