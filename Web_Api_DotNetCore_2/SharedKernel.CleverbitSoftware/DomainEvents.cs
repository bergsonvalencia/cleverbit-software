using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SharedKernel.CleverbitSoftware.Interfaces;

namespace SharedKernel.CleverbitSoftware
{
    public static class DomainEvents
    {
        private static List<Type> _handlers;

        public static void Init()
        {
            _handlers = new List<Type>();

            var coreReferenceAssemblies = Assembly.GetEntryAssembly()?.GetReferencedAssemblies().Where(x => x.FullName.Contains(".Core"));

            if (coreReferenceAssemblies == null) return;

            foreach (var assembly in coreReferenceAssemblies)
            {
                AddHandlers(assembly);
            }
        }

        private static void AddHandlers(AssemblyName assemblyName)
        {
            AddHandlers(Assembly.Load(assemblyName));
        }

        private static void AddHandlers(Assembly assembly)
        {
            _handlers.AddRange(assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IHandler<>)))
                .ToList());
        }

        public static void Raise(IDomainEvent domainEvent)
        {
            foreach (var handlerType in _handlers)
            {
                var canHandleEvent = handlerType.GetInterfaces()
                    .Any(x => x.IsGenericType
                              && x.GetGenericTypeDefinition() == typeof(IHandler<>)
                              && x.GenericTypeArguments[0] == domainEvent.GetType());

                if (!canHandleEvent) continue;

                dynamic handler = Activator.CreateInstance(handlerType);
                handler.Handle((dynamic)domainEvent);
            }
        }
    }
}