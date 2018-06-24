using System.Data;
using System.Data.SqlClient;

namespace DependencyInjection.Source
{
    /// <summary>
    /// Some Database Layer to be used to access a SQL DB.
    /// </summary>
    public class DataBaseLayer
    {
        /// <summary>
        /// This method has a dependency to a concrete SqlCommand class which cannot be mocked away.
        /// The method is untestable unless a real database is provided for testing which
        /// contradicts with the idea of unit testing.
        /// </summary>
        public void DeleteSomeRows(string word)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM excludes WHERE word='@word'";

            var parameter = cmd.CreateParameter();
            parameter.ParameterName = "@word";
            parameter.Value = word;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// This is the refactored version with dependency injection.
        /// The method has a dependency to a abstraction of the SqlCommand, which
        /// is injected to the method ("Method Injection").
        /// It can be unit tested.
        /// </summary>
        public void DeleteSomeRows_Refactored(IDbCommand cmd, string word)
        {
            cmd.CommandText = "DELETE FROM excludes WHERE word='@word'";

            var parameter = cmd.CreateParameter();
            parameter.ParameterName = "@word";
            parameter.Value = word;
            cmd.Parameters.Add(parameter);

            cmd.ExecuteNonQuery();
        }
    }
}
