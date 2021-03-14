using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTests
{
    public class PatientTests
    {
        [Fact]
        public void BeNewWhenCreate()
        {
            //Arrange
            var patient = new Patient();

            //Act
            var result = patient.IsNew;

            //Assert
            //boolean类型的assert
            Assert.True(result);
        }

        [Fact]
        public void HaveCorrectFullName()
        {
            //Arrange
            var patient = new Patient()
            {
                FirstName = "Nick",
                LastName = "Carter",
            };

            //Act
            var fullName = patient.FullName;

            //Assert
            //string类型的assert 
            Assert.Equal("Nick Carter", fullName);
            Assert.StartsWith("Nick", fullName);
            Assert.EndsWith("Carter", fullName);
            Assert.Contains("Nick", fullName);
            Assert.Matches(@"^[A-Z][a-z]*\s[A-Z][a-z]*", fullName);
        }

        [Fact]
        public void HaveDefaultBloodSugarWhenCreated()
        {
            var p = new Patient();
            var boolSugar = p.BloodSugar;

            //数值型的assert 
            Assert.Equal(4.9f, boolSugar, 5);
            Assert.InRange(boolSugar, 3.9, 6.1);
        }

        [Fact]
        public void HaveNoNameWhenCreated()
        {
            var p = new Patient();
            Assert.Null(p.FirstName);
            Assert.NotNull(p);
        }

        [Fact]
        public void HaveHadAColdBefore()
        {
            var p = new Patient();

            var diseases = new List<string>
            {
                "感冒",
                "发烧",
                "水痘",
                "腹泻"
            };

            p.History.Add("感冒");
            p.History.Add("发烧");
            p.History.Add("水痘");
            p.History.Add("腹泻");

            //集合类型的assert 
            Assert.Contains("感冒", p.History);
            Assert.DoesNotContain("心脏病", p.History);

            //判断p.History至少有一个元素：水
            Assert.Contains(p.History, x => x.StartsWith("水"));

            Assert.All(p.History, x => Assert.True(x.Length >= 2));

            //判断集合是否相等,是比较集合元素的值，而不是比较引用
            Assert.Equal(diseases, p.History);

        }

        [Fact]
        public void BeAPerson()
        {
            var p = new Patient();
            var p2 = new Patient();

            //Object类型的assert 

            //判断精确类型
            Assert.IsNotType<Person>(p);
            Assert.IsType<Patient>(p);

            //判断继承某类型
            Assert.IsAssignableFrom<Person>(p);

            //判断是否为同一个实例
            Assert.NotSame(p, p2);
            //Assert.Same(p, p2);

        }

        [Fact]
        public void ThrowException() //注意不能使用ctrl+R,T快捷键
        {
            var p = new Patient();
      
            //断言是否发生异常
            var ex = Assert.Throws<InvalidOperationException>(() => { p.NotAllowed(); });
            Assert.Equal("not able to create", ex.Message);
        }

        [Fact]
        public void RaizeSleepEvent()
        {
            var p = new Patient();

            //断言是否触发事件
            Assert.Raises<EventArgs>(
                handler => p.PatientSlept += handler,
                handler => p.PatientSlept -= handler,
                () => p.OnPatientSleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            var p = new Patient();
            // 断言属性改变事件是否触发
            Assert.PropertyChanged(p, nameof(p.HeartBeatRate),
                () => p.IncreaseHeartBeatRate());
        }
    }
}
