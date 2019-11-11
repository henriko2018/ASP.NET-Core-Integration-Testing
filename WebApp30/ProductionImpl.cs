namespace WebApp30
{
    public class ProductionImpl : ISomeService
    {
	    public string Ping()
	    {
		    return GetType().Name;
	    }
    }
}
