using DN.UserControlApp.Infra.Data.ORM.Contexts;
using DN.UserControlApp.SharedKernel.Repositories.Contracts;

namespace DN.UserControlApp.Infra.Data.Transaction
{
    public sealed class UnityOfWork : IUnityOfWork
    {
        private UserControlDataContext _context;


        public UnityOfWork(UserControlDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
