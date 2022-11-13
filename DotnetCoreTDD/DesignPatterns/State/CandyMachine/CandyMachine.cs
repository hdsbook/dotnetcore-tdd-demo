using System;
using System.Runtime.Serialization;

namespace DotnetCoreTDD.DesignPatterns.State.CandyMachine
{
    /// <summary>
    /// 糖果販賣機類別
    /// </summary>
    public class CandyMachine
    {
        /// <summary>
        /// 糖果剩餘數量
        /// </summary>
        private int _candyCount;

        /// <summary>
        /// 販賣機狀態
        /// </summary>
        private MachineState _state;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="candyCount">初始糖果數量</param>
        public CandyMachine(int candyCount)
        {
            _candyCount = candyCount;
            _state = candyCount > 0
                ? (MachineState) new NoCoinState() // 糖果數量大於零，預設狀態為無硬幣
                : (MachineState) new SoldOutState(); // 糖果數量為零，狀態為已賣完
        }

        public int GetCandyCount()
        {
            return _candyCount;
        }

        /// <summary>
        /// 切換販賣機狀態
        /// </summary>
        /// <param name="newState"></param>
        public void TurnIntoState(MachineState newState)
        {
            _state = newState;
            
            // 將狀態的 context 設為自己，狀態即可透過 context 呼叫此 TurnIntoState 方法進行狀態轉換
            _state.SetContext(this); 
        }

        /// <summary>
        /// 投幣
        /// </summary>
        public void InsertCoin()
        {
            _state.InsertCoin();
        }

        /// <summary>
        /// 退幣
        /// </summary>
        public void Refund()
        {
            _state.Refund();
        }

        /// <summary>
        /// 轉動旋鈕
        /// </summary>
        public void TurnCrank()
        {
            _state.TurnCrank();
        }

        /// <summary>
        /// 將糖果包裝送出
        /// </summary>
        public void Dispense()
        {
            _state.Dispense();
        }

        public void ConsumeCandyCount()
        {
            _candyCount = _candyCount - 1;
        }

        public MachineState GetState()
        {
            return _state;
        }
    }


    /// <summary>
    /// 販賣機狀態介面
    /// </summary>
    public abstract class MachineState
    {
        protected CandyMachine Context;
        public abstract void InsertCoin();

        public abstract void Refund();

        public abstract void TurnCrank();

        public abstract void Dispense();

        public void SetContext(CandyMachine machine)
        {
            Context = machine;
        }
    }

    /// <summary>
    /// 狀態：已賣完
    /// </summary>
    public class SoldOutState : MachineState
    {
        public override void InsertCoin()
        {
            throw new CandyMachineException("糖果已賣完，不再接受投幣");
        }

        public override void Refund()
        {
            throw new CandyMachineException("糖果已賣完，不接受投幣，亦不接受退幣服務");
        }

        public override void TurnCrank()
        {
            throw new CandyMachineException("糖果已賣完，無法轉動");
        }

        public override void Dispense()
        {
            throw new CandyMachineException("糖果已賣完，不接受此操作");
        }
    }

    /// <summary>
    /// 狀態：糖果未賣完但還沒投幣
    /// </summary>
    public class NoCoinState : MachineState
    {
        public override void InsertCoin()
        {
            Context.TurnIntoState(new HasCoinState());
        }

        public override void Refund()
        {
            throw new CandyMachineException("尚未投幣，無法推幣");
        }

        public override void TurnCrank()
        {
            throw new CandyMachineException("尚未投幣，無法轉動");
        }

        public override void Dispense()
        {
            throw new CandyMachineException("尚未投幣，無法進行此操作");
        }
    }

    /// <summary>
    /// 狀態：已投幣
    /// </summary>
    public class HasCoinState : MachineState
    {
        public override void InsertCoin()
        {
            throw new CandyMachineException("您已投幣，請完成交易後再投幣");
        }

        public override void Refund()
        {
            // 進行退幣…

            // 切換為無幣狀態
            Context.TurnIntoState(new NoCoinState());
        }

        public override void TurnCrank()
        {
            // 轉動旋鈕後，進入交易中狀態
            Context.TurnIntoState(new SoldState());
        }

        public override void Dispense()
        {
            throw new CandyMachineException("請先轉動旋鈕");
        }
    }

    /// <summary>
    /// 狀態：交易進行中
    /// </summary>
    public class SoldState : MachineState
    {
        public override void InsertCoin()
        {
            throw new CandyMachineException("交易進行中，請稍候再進行投幣");
        }

        public override void Refund()
        {
            throw new CandyMachineException("交易進行中，無法退幣");
        }

        public override void TurnCrank()
        {
            throw new CandyMachineException("交易進行中，無法轉動旋鈕");
        }

        public override void Dispense()
        {
            Context.ConsumeCandyCount();

            var nextState = Context.GetCandyCount() > 0
                ? (MachineState) new NoCoinState()
                : (MachineState) new SoldOutState();

            Context.TurnIntoState(nextState);
        }
    }
    
    public class CandyMachineException : Exception
    {
        public CandyMachineException(string message): base(message)
        {
        }
    }
}