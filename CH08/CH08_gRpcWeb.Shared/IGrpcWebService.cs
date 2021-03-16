namespace CH08_gRpcWeb.Shared
{
	using System.ServiceModel;
	using System.Threading.Tasks;

	[ServiceContract]
	public interface IGrpcWebService
	{
		Task<GrpcWebResponse> DoWork(GrpcWebRequest request);
	}
}
