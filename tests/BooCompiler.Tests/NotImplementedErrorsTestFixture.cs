
namespace BooCompiler.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class NotImplementedErrorsTestFixture : AbstractCompilerErrorsTestFixture
	{



		override protected string GetRelativeTestCasesPath()
		{
			return "not-implemented";
		}
	}
}
