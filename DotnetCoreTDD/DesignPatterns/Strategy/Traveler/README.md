> RawTraveler 是沒有完全採用Strategy模式的物件(也就是沒有把switch抽離出去)
> 
> Traveler則是完全採用Strategy的物件

- 核心邏輯物件：
    - Traveler

- 策略物件(IGoStrategy)：
    - GoByBus
    - GoByTrain