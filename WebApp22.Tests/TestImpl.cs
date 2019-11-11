namespace WebApp22.Tests
{
    public class TestImpl : ISomeService
    {
	    public string Ping()
	    {
		    return GetType().Name;
	    }
    }
}
