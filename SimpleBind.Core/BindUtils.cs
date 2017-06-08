using System.Linq.Expressions;
using System.Reflection;

namespace SimpleBind.Core
{
    internal static class BindUtils
    {
        /// <summary>
        /// Obter propriedade/variável que foi referênciada na expressão
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MemberInfo GetExpressionMember(Expression expression)
        {
            if (expression is LambdaExpression)
                expression = ((LambdaExpression) expression).Body;

            if (expression is UnaryExpression)
                expression = ((UnaryExpression) expression).Operand;

            var lMemberExpr = expression as MemberExpression;

            return lMemberExpr?.Member;
        }
    }
}