using Demo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DemoTests
{
    [Collection("Long Time Task Collection")]
    public class PatientShould:IClassFixture<LongTimeTaskFixture>,IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Patient _patient;
        private readonly LongTimeTask _task;
        private readonly LongTimeTaskFixture _fixture;
        public PatientShould(ITestOutputHelper output, LongTimeTaskFixture fixture)
        {
            this._output = output;
            _patient = new Patient();
            _task = fixture.Task;
        }

        /// <summary>
        /// 布尔型
        /// </summary>
        [Fact]
        [Trait("Category","New")]
        public void BeNewWhenCreated()
        {
            _output.WriteLine("第一个测试");

            // Act
            var result = _patient.IsNew;

            // Assert
            Assert.True(result);  // 期待结果为true
            // Assert.False(result);  // 期待结果为False
        }

        /// <summary>
        /// 字符串
        /// </summary>
        [Fact]
        public void HaveCorrectFullName()
        {
            // Arrange
            _patient.FirstName = "Nick";
            _patient.LastName = "Carter";

            // Act
            var fullName = _patient.FullName;

            // Assert
            Assert.Equal("Nick Carter",fullName);
            Assert.NotEqual("NICK CARTER",fullName);
            Assert.StartsWith("Nick",fullName);
            Assert.EndsWith("Carter", fullName);
            Assert.Contains("Nick Carter", fullName);
            Assert.Contains("ck Car", fullName);
            Assert.Matches(@"^[A-Z][a-z]*\s[A-Z][a-z]*", fullName);  // 正则表达式
        }

        /// <summary>
        /// 数值型
        /// </summary>
        [Fact]
        [Trait("Category", "New")]
        [Trait("Category", "Name")]
        public void HaveDefaultBloodSugarWhenCreated()
        {
            // Act
            var bloodSugar = _patient.BloodSugar;

            // Assert
            Assert.Equal(4.9f, bloodSugar,2);
            Assert.InRange(bloodSugar,3.9f,6.1f);
        }

        /// <summary>
        /// Null
        /// </summary>
        [Fact]
        public void HaveNoNameWhenCreated()
        {
            // Assert
            Assert.Null(_patient.FirstName);
            Assert.NotNull(_patient);
        }

        /// <summary>
        /// 集合
        /// </summary>
        [Fact(Skip ="不需要跑这个测试")]
        public void HaveHadAColdBefore()
        {
            // Arrange
            List<string> diseases = new List<string>
            {
                "感冒",
                "发烧",
                "水痘",
                "腹泻"
            };

            // Act
            _patient.History.Add("感冒");
            _patient.History.Add("发烧");
            _patient.History.Add("水痘");
            _patient.History.Add("腹泻");

            // Assert
            Assert.Contains("感冒", _patient.History);
            Assert.DoesNotContain("心脏病", _patient.History);

            // Predicate
            Assert.Contains(_patient.History, x => x.StartsWith("水")); // 集合中至少有一个元素符合条件
            Assert.All(_patient.History, x => Assert.True(x.Length >= 2)); // 集合中每个元素长度都大于等于2
            Assert.Equal(diseases, _patient.History); // 判断集合这个元素值的相等
        }

        /// <summary>
        /// 对象
        /// </summary>
        [Fact]
        public void BeAPerson()
        {
            // Arrange
            Patient patient2 = new Patient();

            // Assert
            Assert.IsType<Patient>(_patient);
            Assert.IsNotType<Person>(_patient);
            Assert.IsAssignableFrom<Person>(_patient);
            Assert.NotSame(_patient, patient2);
        }

        /// <summary>
        /// 异常
        /// </summary>
        [Fact]
        public void ThrowExceptionsWhenErrorOccurred()
        {
            // Assert
            var ex= Assert.Throws<InvalidOperationException>(()=> _patient.NotAllowed());
            Assert.Equal("Not able to create",ex.Message);
        }

        /// <summary>
        /// 事件
        /// </summary>
        [Fact]
        public void RaiseSleptEvent()
        {
            // Assert 
            Assert.Raises<EventArgs>(
                handler=> _patient.PatientSlept+=handler,
                handler=> _patient.PatientSlept-=handler,
                ()=> _patient.Sleep());
        }

        /// <summary>
        /// 属性改变
        /// </summary>
        [Fact]
        public void RaisePropertyChangedEvent()
        {
            // Assert
            Assert.PropertyChanged(_patient, nameof(_patient.HeartBeatRate), () => _patient.IncreaseHeartBeatRate());
        }

        public void Dispose()
        {
            _output.WriteLine("清理了资源");
        }
    }
}
