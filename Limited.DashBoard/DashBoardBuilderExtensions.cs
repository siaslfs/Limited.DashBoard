using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Limited.DashBoard
{
    public static class DashBoardBuilderExtensions
    {
        public static IApplicationBuilder DashBoard(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DashBoardMiddleware>();

        }
    }
}
