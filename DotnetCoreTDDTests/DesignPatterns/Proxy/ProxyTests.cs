using DotnetCoreTDD.DesignPatterns.Proxy;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Proxy
{
    [TestFixture]
    public class ProxyTests
    {
        [Test]
        public void Operation_WithoutProxy_WorksCorrectly()
        {
            // given service
            var service = new ProxyUml.RealService();

            // when do operation
            var result = service.Operation();
            
            // then
            result.Should().Be("ok");
        }
        
        [Test]
        public void Operation_WithDenyProxy_WorksCorrectly()
        {
            // given service
            ProxyUml.IService service = new ProxyUml.RealService();

            // when wrap service with proxy and do operation
            service = new ProxyUml.ProxyAlwaysDeny(service);
            var result = service.Operation();
            
            // then
            result.Should().BeEmpty();
        }
    }
}