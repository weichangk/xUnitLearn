using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.UnitTests
{
    [Collection("Lone Time Task Collection")]
    public class PatientTests2 : IClassFixture<LongTimeFixture>,IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Patient _patient;
        private readonly LongTimeTask _task;
        public PatientTests2(ITestOutputHelper output, LongTimeFixture fixture)
        {
            _output = output;
            _patient = new Patient();//统一在构造函数中生成对象
            _task = fixture.Task;//共享资源，只创建一次，防止运行每个测试方法调用构造函数重复创建资源。
        }

        [Fact]
        [Trait("Category", "New")]
        public void BeNewWhenCreate()
        {
            _output.WriteLine("第一个测试");

            //Arrange
            //var patient = new Patient();

            //Act
            var result = _patient.IsNew;

            //Assert
            //boolean类型的assert
            Assert.True(result);
        }

        [Fact]
        public void HaveCorrectFullName()
        {
            //Arrange
            //var patient = new Patient()
            //{
            //    FirstName = "Nick",
            //    LastName = "Carter",
            //};
            _patient.FirstName = "Nick";
            _patient.LastName = "Carter";
            
            //Act
            var fullName = _patient.FullName;

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
            //var p = new Patient();
            var boolSugar = _patient.BloodSugar;

            //数值型的assert 
            Assert.Equal(4.9f, boolSugar, 5);
            Assert.InRange(boolSugar, 3.9, 6.1);
        }

        [Fact]
        public void HaveNoNameWhenCreated()
        {
            //var p = new Patient();
            Assert.Null(_patient.FirstName);
            Assert.NotNull(_patient);
        }

        [Fact(Skip = "暂时忽略这个测试")]
        public void HaveHadAColdBefore()
        {
            //var p = new Patient();

            var diseases = new List<string>
            {
                "感冒",
                "发烧",
                "水痘",
                "腹泻"
            };

            _patient.History.Add("感冒");
            _patient.History.Add("发烧");
            _patient.History.Add("水痘");
            _patient.History.Add("腹泻");

            //集合类型的assert 
            Assert.Contains("感冒", _patient.History);
            Assert.DoesNotContain("心脏病", _patient.History);

            //判断p.History至少有一个元素：水
            Assert.Contains(_patient.History, x => x.StartsWith("水"));

            Assert.All(_patient.History, x => Assert.True(x.Length >= 2));

            //判断集合是否相等,是比较集合元素的值，而不是比较引用
            Assert.Equal(diseases, _patient.History);

        }

        [Fact]
        public void BeAPerson()
        {
            //var p = new Patient();
            var p2 = new Patient();

            //Object类型的assert 

            //判断精确类型
            Assert.IsNotType<Person>(_patient);
            Assert.IsType<Patient>(_patient);

            //判断继承某类型
            Assert.IsAssignableFrom<Person>(_patient);

            //判断是否为同一个实例
            Assert.NotSame(_patient, p2);
            //Assert.Same(_patient, p2);

        }

        [Fact]
        public void ThrowException() //注意不能使用ctrl+R,T快捷键
        {
            //var p = new Patient();
      
            //断言是否发生异常
            var ex = Assert.Throws<InvalidOperationException>(() => { _patient.NotAllowed(); });
            Assert.Equal("not able to create", ex.Message);
        }

        [Fact]
        public void RaizeSleepEvent()
        {
            //var p = new Patient();

            //断言是否触发事件
            Assert.Raises<EventArgs>(
                handler => _patient.PatientSlept += handler,
                handler => _patient.PatientSlept -= handler,
                () => _patient.OnPatientSleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //var p = new Patient();
            // 断言属性改变事件是否触发
            Assert.PropertyChanged(_patient, nameof(_patient.HeartBeatRate),
                () => _patient.IncreaseHeartBeatRate());
        }

        public void Dispose()
        {
            //可以实现Dispose释放资源
            _output.WriteLine("Dispose...");
        }
    }
}
