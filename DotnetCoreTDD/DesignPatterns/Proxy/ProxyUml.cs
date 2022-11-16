namespace DotnetCoreTDD.DesignPatterns.Proxy
{
    public class ProxyUml
    {
        public interface IService
        {
            public string Operation();
        }
        
        public class RealService: IService
        {
            public string Operation()
            {
                return "ok";
            }
        }
        
        public class ProxyAlwaysDeny: IService
        {
            public IService Service { get; set; }

            public ProxyAlwaysDeny(IService service)
            {
                Service = service;
            }


            public string Operation()
            {
                var result = string.Empty;
                
                // 做權限驗證，驗證通過才執行
                if (CheckAccess())
                {
                    result = Service.Operation();

                    // maybe 這邊還可以做一些 log 紀錄
                }

                return result;
            }

            public virtual bool CheckAccess()
            {
                return false; // 這邊採取總是拒絕
            }
        }
    }
}