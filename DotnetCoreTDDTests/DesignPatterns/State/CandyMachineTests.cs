using System;
using DotnetCoreTDD.DesignPatterns.State.CandyMachine;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.State
{
    [TestFixture]
    public class CandyMachineTests
    {
        [Test]
        public void OperateMachine_WhenSoldOut_WorksCorrectly()
        {
            CandyMachine machine;
            Exception ex;
            
            // given SoldOut 狀態的販賣機
            machine = CandyMachineFactory.Create(new SoldOutState(), 0);

            // when 投幣, then 預期拋錯
            ex = Assert.Throws<CandyMachineException>(() => machine.InsertCoin());
            ex.Message.Should().Contain("糖果已賣完");

            // when 退幣, then 預期拋錯
            machine = CandyMachineFactory.Create(new SoldOutState(), 0);
            ex = Assert.Throws<CandyMachineException>(() => machine.Refund());
            ex.Message.Should().Contain("糖果已賣完");
            
            // when 轉動旋鈕, then 預期拋錯
            machine = CandyMachineFactory.Create(new SoldOutState(), 0);
            ex = Assert.Throws<CandyMachineException>(() => machine.TurnCrank());
            ex.Message.Should().Contain("糖果已賣完");
            
            
            // when 包裝送出, then 預期拋錯
            machine = CandyMachineFactory.Create(new SoldOutState(), 0);
            ex = Assert.Throws<CandyMachineException>(() => machine.Dispense());
            ex.Message.Should().Contain("糖果已賣完");
        }
        
        [Test]
        public void OperateMachine_WhenNoCoin_WorksCorrectly()
        {
            CandyMachine machine;
            Exception ex;
            
            // given NoCoin狀態的販賣機
            machine = CandyMachineFactory.Create(new NoCoinState());

            // when 投幣, then 預期狀態轉為 HasCoin
            Assert.That(() => machine.InsertCoin(), Throws.Nothing);
            machine.GetState().Should().BeOfType<HasCoinState>();

            // when 重設狀態、退幣, then 預期拋錯
            machine = CandyMachineFactory.Create(new NoCoinState());
            ex = Assert.Throws<CandyMachineException>(() => machine.Refund());
            ex.Message.Should().Contain("尚未投幣");
            
            // when 重設狀態、轉動旋鈕, then 預期拋錯
            machine = CandyMachineFactory.Create(new NoCoinState());
            ex = Assert.Throws<CandyMachineException>(() => machine.TurnCrank());
            ex.Message.Should().Contain("尚未投幣");
            
            
            // when 重設狀態、包裝送出, then 預期拋錯
            machine = CandyMachineFactory.Create(new NoCoinState());
            ex = Assert.Throws<CandyMachineException>(() => machine.Dispense());
            ex.Message.Should().Contain("尚未投幣");
        }
        
        [Test]
        public void OperateMachine_WhenHasCoin_WorksCorrectly()
        {
            CandyMachine machine;
            Exception ex;
            
            // given HasCoin狀態的販賣機
            machine = CandyMachineFactory.Create(new HasCoinState());

            // when 投幣, then 預期拋錯
            machine = CandyMachineFactory.Create(new HasCoinState());
            ex = Assert.Throws<CandyMachineException>(() => machine.InsertCoin());
            ex.Message.Should().Contain("您已投幣，請完成交易後再投幣");

            // when 退幣, then 預期狀態轉為 NoCoin
            machine = CandyMachineFactory.Create(new HasCoinState());
            Assert.That(() => machine.Refund(), Throws.Nothing);
            machine.GetState().Should().BeOfType<NoCoinState>();
            
            // when 轉動旋鈕, then 預期狀態轉為 Sold
            machine = CandyMachineFactory.Create(new HasCoinState());
            Assert.That(() => machine.TurnCrank(), Throws.Nothing);
            machine.GetState().Should().BeOfType<SoldState>();

            // when 包裝送出, then 預期拋錯
            machine = CandyMachineFactory.Create(new HasCoinState());
            ex = Assert.Throws<CandyMachineException>(() => machine.Dispense());
            ex.Message.Should().Contain("請先轉動旋鈕");
        }
        
        [Test]
        public void OperateMachine_WhenSold_WorksCorrectly()
        {
            CandyMachine machine;
            Exception ex;
            
            // given Sold狀態的販賣機
            machine = CandyMachineFactory.Create(new SoldState());

            // when 投幣, then 預期拋錯
            machine = CandyMachineFactory.Create(new SoldState());
            ex = Assert.Throws<CandyMachineException>(() => machine.InsertCoin());
            ex.Message.Should().Contain("交易進行中");

            // when 重設狀態、退幣, then 預期拋錯
            machine = CandyMachineFactory.Create(new SoldState());
            ex = Assert.Throws<CandyMachineException>(() => machine.Refund());
            ex.Message.Should().Contain("交易進行中");
            
            // when 重設狀態、轉動旋鈕, then 預期拋錯
            machine = CandyMachineFactory.Create(new SoldState());
            ex = Assert.Throws<CandyMachineException>(() => machine.TurnCrank());
            ex.Message.Should().Contain("交易進行中");
            
            // when 重設狀態且只含一顆糖、包裝送出, then 預期狀態轉為已賣完狀態
            machine = CandyMachineFactory.Create(new SoldState(), 1);
            Assert.That(() => machine.Dispense(), Throws.Nothing);
            machine.GetState().Should().BeOfType<SoldOutState>();

            // when 重設狀態且含兩顆糖、包裝送出, then 預期狀態轉為無硬幣狀態
            machine = CandyMachineFactory.Create(new SoldState(), 2);
            Assert.That(() => machine.Dispense(), Throws.Nothing);
            machine.GetState().Should().BeOfType<NoCoinState>();
        }

        public static class CandyMachineFactory
        {
            public static CandyMachine Create(MachineState state, int candyCount = 10)
            {
                var machine = new CandyMachine(candyCount);
                machine.TurnIntoState(state);
                return machine;
            }
        }
    }
}