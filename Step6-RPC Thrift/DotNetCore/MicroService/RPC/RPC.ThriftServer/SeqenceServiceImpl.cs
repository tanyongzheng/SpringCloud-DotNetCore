using System;
using System.Threading;
using System.Threading.Tasks;
using RPC.ThriftInterface;

namespace RPC.ThriftServer
{
    public class SeqenceServiceImpl: SeqenceServiceInterface.IAsync
    {
        public async Task<int> GetIDSeqenceAsync(string tableName, CancellationToken cancellationToken)
        {
            var second= DateTime.Now.Second;

            return await Task.FromResult(second);
        }

        public async Task<int> GetCodeSeqenceAsync(int type, string id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(type);
        }
    }
}