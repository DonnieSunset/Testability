using DependencyInjection.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace DependencyInjection.Test
{
    [TestClass]
    public class DataBaseLayerTests
    {
        [TestMethod]
        public void DeleteSomeRows_ValidParameter_DeleteCallTriggered()
        {
            // arrange
            var cut = new DataBaseLayer();
            var myparameterList = new List<object>();
            var dbCommandMock = CreateCommandMock(myparameterList);
            var paramValue = "myTestString";

            // act: here the dependency injection happens (its called "method injection")
            cut.DeleteSomeRows_Refactored(dbCommandMock.Object, paramValue);

            // assert that parameters were assigned correctly
            var myExpectedParamName = GetParamNameFromQuery(dbCommandMock.Object.CommandText);
            var myExpectedParamValue = paramValue;

            var myActualParamName = ((IDbDataParameter)myparameterList[0]).ParameterName;
            var myActualParamValue = ((IDbDataParameter)myparameterList[0]).Value;

            Assert.AreEqual(myExpectedParamName, myActualParamName);
            Assert.AreEqual(myExpectedParamValue, myActualParamValue);

            // assert that query was executed
            dbCommandMock.Verify(foo => foo.ExecuteNonQuery(), Times.Exactly(1));
        }

        private string GetParamNameFromQuery(string query)
        {
            var regex = new Regex(@"DELETE FROM excludes WHERE word='(@\S+)'");
            var match = regex.Match(query);

            if (match.Success)
                return match.Groups[1].Value;
            else
                return null;
        }

        private Mock<IDbCommand> CreateCommandMock(ICollection<object> parameterList)
        {
            var dbCommandMock = new Mock<IDbCommand>();
            var dbparameterMock = new Mock<IDbDataParameter>();
            var dbparameterCollectionMock = new Mock<IDataParameterCollection>();

            dbCommandMock
                .Setup(foo => foo.CreateParameter())
                .Returns(dbparameterMock.Object);
            dbCommandMock
                .Setup(foo => foo.Parameters)
                .Returns(dbparameterCollectionMock.Object);
            dbCommandMock
                .SetupProperty(foo => foo.CommandText);    //make properties assignable

            dbparameterMock
                .SetupProperty(foo => foo.ParameterName);
            dbparameterMock
                .SetupProperty(foo => foo.Value);

            // if the add method is called, we trigger to add into our local list
            dbparameterCollectionMock
                .Setup(foo => foo.Add(It.IsAny<IDbDataParameter>()))
                .Callback<object>((s) => parameterList.Add(s));

            return dbCommandMock;
        }
    }
}
