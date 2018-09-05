using System;
using System.Threading;
using RPC.ThriftInterface;
using Thrift;
using Thrift.Collections;
using Thrift.Protocols;
using Thrift.Server;
using Thrift.Transports;
using Thrift.Transports.Server;
using Microsoft.Extensions.Logging;

namespace RPC.ThriftServer
{
    public class Server
    {
        public static void Start()
        {
            var logger = new LoggerFactory().CreateLogger("ThriftServer");
            int thriftPort = 5551;
            Console.Title = "Thrift服务端-Server";
            try
            {
                TServerTransport serverTransport = new TServerSocketTransport(thriftPort);//使用Socket进行通信 TcpBuffered
                SeqenceServiceInterface.AsyncProcessor processor = new SeqenceServiceInterface.AsyncProcessor(new SeqenceServiceImpl());
                ITProcessorFactory processorFactory = new SingletonTProcessorFactory(processor);
                TTransportFactory transFactory = new TTransportFactory();
                ITProtocolFactory proto = new TBinaryProtocol.Factory();//使用二进制传输
                TBaseServer serverEngine = new AsyncBaseServer(processorFactory, serverTransport, transFactory,
                    transFactory, proto, proto, logger);
                Console.WriteLine($"启动Thrift服务器，监听端口: {thriftPort}");
                serverEngine.ServeAsync(CancellationToken.None).GetAwaiter().GetResult();
            }
            catch (Exception x)
            {
                Console.Error.Write(x);
            }
            Console.WriteLine("启动成功！");
        }


        public static void StartMultiplexed()
        {
            var fabric = new LoggerFactory().AddConsole(LogLevel.Trace).AddDebug(LogLevel.Trace);
            int thriftPort = 5551;
            Console.Title = "Thrift服务端-Server";
            try
            {
                TServerTransport serverTransport = new TServerSocketTransport(thriftPort);//使用Socket进行通信 TcpBuffered
                var multiplexedProcessor = new TMultiplexedProcessor();//多个服务
                SeqenceServiceInterface.AsyncProcessor seqenceProcessor = new SeqenceServiceInterface.AsyncProcessor(new SeqenceServiceImpl());
                multiplexedProcessor.RegisterProcessor(nameof(SeqenceServiceInterface), seqenceProcessor);
                //multiplexedProcessor.RegisterProcessor(nameof(SharedService), sharedServiceProcessor);
                ITAsyncProcessor processor = multiplexedProcessor;
                ITProtocolFactory proto = new TBinaryProtocol.Factory();//使用二进制传输
               TBaseServer serverEngine = new AsyncBaseServer(processor, serverTransport, proto, proto, fabric);
                Console.WriteLine($"启动Thrift服务器，监听端口: {thriftPort}");
                serverEngine.ServeAsync(CancellationToken.None).GetAwaiter().GetResult();
            }
            catch (Exception x)
            {
                Console.Error.Write(x);
            }
            Console.WriteLine("启动成功！");
        }
    }
}