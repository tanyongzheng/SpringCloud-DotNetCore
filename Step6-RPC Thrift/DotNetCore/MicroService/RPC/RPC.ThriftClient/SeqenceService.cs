using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RPC.ThriftInterface;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace RPC.ThriftClient
{
    public class SeqenceService
    {

         private  int thriftPort = 5551;

        public async Task<int> GetIDSeqenceAsync(string tableName)
        {
            using (var source = new CancellationTokenSource())
            {
                TClientTransport clientTransport =
                    new TBufferedClientTransport(new TSocketClientTransport(IPAddress.Loopback, thriftPort));
                TProtocol protocol = new TBinaryProtocol(clientTransport); //使用二进制字节传输
                // it uses binary protocol there  to create Multiplexed protocols
                var multiplex = new TMultiplexedProtocol(protocol, nameof(SeqenceServiceInterface));
                var client = new SeqenceServiceInterface.Client(multiplex);
                await client.OpenTransportAsync(source.Token);
                return await client.GetIDSeqenceAsync(tableName, source.Token);
            }
        }

        public async Task<int> GetCodeSeqenceAsync(int type, string id)
        {
            using (var source = new CancellationTokenSource())
            {
                TClientTransport clientTransport =
                    new TBufferedClientTransport(new TSocketClientTransport(IPAddress.Loopback, thriftPort));
                TProtocol protocol = new TBinaryProtocol(clientTransport); //使用二进制字节传输
                // it uses binary protocol there  to create Multiplexed protocols
                var multiplex = new TMultiplexedProtocol(protocol, nameof(SeqenceServiceInterface));
                var client = new SeqenceServiceInterface.Client(multiplex);
                await client.OpenTransportAsync(source.Token);
                return await client.GetCodeSeqenceAsync(type, id, source.Token);
            }
        }
    }
}