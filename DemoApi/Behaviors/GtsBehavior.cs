using MediatR;

namespace DemoApi.Behaviors
{
    public class GtsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            var costProperty = response.GetType().GetProperties().Where(x => x.Name == "Cost").FirstOrDefault();

            if (costProperty != null)
            {
                var cost = (decimal)costProperty.GetValue(response);
                cost *= 1.05m;
                costProperty.SetValue(response, cost);
            }

            return response;
        }
    }
}
