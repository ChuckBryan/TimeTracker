using System.Data.Entity;
using System.Web;
using TimeTracker.Web.Data;
using TimeTracker.Web.Infrastructure.Tasks;

namespace TimeTracker.Web.Infrastructure
{
    /*NOTE: May need to change this to use System.Transactions for Azure?*/
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly AppDbContext _dbContext;
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(AppDbContext dbContext,
            HttpContextBase httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {
            _httpContext.Items["_Transaction"] =
                _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        void IRunOnError.Execute()
        {
            _httpContext.Items["_Error"] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            var transaction = (DbContextTransaction)_httpContext.Items["_Transaction"];

            if (_httpContext.Items["_Error"] != null)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }
    }
}