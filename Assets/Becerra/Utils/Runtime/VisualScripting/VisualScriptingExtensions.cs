using Unity.VisualScripting;
using Zenject;

namespace Becerra.Game.VisualScripting
{
    public static class VisualScriptingExtensions
    {
        public static void InjectGraph(this IGraph graph, DiContainer zenject)
        {
            if (graph is StateGraph stateGraph)
            {
                stateGraph.InjectStateGraph(zenject);
            }
            else if (graph is FlowGraph flowGraph)
            {
                flowGraph.InjectFlowGraph(zenject);
            }
        }

        public static void Inject(this IGraphElement element, DiContainer zenject)
        {
            if (element is INesterState nesterState)
            {
                nesterState.InjectNesterState(zenject);
            }
            else if (element is INesterStateTransition nesterTransition)
            {
                nesterTransition.InjectNersterTransition(zenject);
            }
            else if (element is INesterUnit nester)
            {
                nester.InjectNesterUnit(zenject);
            }
            else if (element is IUnit unit)
            {
                unit.InjectUnit(zenject);
            }
        }

        public static void InjectNesterState(this INesterState nester, DiContainer zenject)
        {
            var nestedGraph = nester.nest.graph;

            nestedGraph.InjectGraph(zenject);
        }

        public static void InjectNersterTransition(this INesterStateTransition nesterTransition, DiContainer zenject)
        {
            var nestedGraph = nesterTransition.nest.graph;

            nestedGraph.InjectGraph(zenject);
        }

        public static void InjectUnit(this IUnit unit, DiContainer zenject)
        {
            if (unit is IInjectableUnit injectableUnit)
            {
                zenject.Inject(injectableUnit);
            }
        }

        public static void InjectNesterUnit(this INesterUnit nester, DiContainer zenject)
        {
            nester.InjectUnit(zenject);

            var nestedGraph = nester.childGraph;

            nestedGraph.InjectGraph(zenject);
        }

        public static void InjectStateGraph(this StateGraph graph, DiContainer zenject)
        {
            var elements = graph.elements;

            foreach (var element in elements)
            {
                element.Inject(zenject);
            }
        }

        public static void InjectFlowGraph(this FlowGraph graph, DiContainer zenject)
        {
            var elements = graph.elements;

            foreach (var element in elements)
            {
                element.Inject(zenject);
            }
        }
    }
}