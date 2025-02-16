﻿namespace ChampionsDraft.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizableSocketsHttpHandler(this IServiceCollection services)
        {
            SocketsHttpHandler socketsHttpHandler = new()
            {
                // Customize this value based on desired DNS refresh timer
                PooledConnectionLifetime = TimeSpan.FromMinutes(5)
            };
            // Registering the Singleton SocketsHttpHandler lets you reuse it across any HttpClient in your application
            services.AddSingleton(socketsHttpHandler);

            return services;
        }
    }
}
