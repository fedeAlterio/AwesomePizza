using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Web.Endpoints.Menu.GetMenu;

public class GetMenuWebRequest : IRequest<Ok<GetMenuWebResponse>>;
