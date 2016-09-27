using System;

namespace DN.UserControlApp.SharedKernel.Repositories.Contracts
{
    public interface IUnityOfWork : IDisposable
    {
        void Commit();
    }
}
