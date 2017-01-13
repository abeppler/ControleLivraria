using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleLivraria2.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Retorna as linhas selecionadas do grid.
        /// </summary>
        /// <param name="checkBoxId">Nome do controle checkBox.</param>
        /// <returns></returns>
        public static List<GridViewRow> GetCheckedRows(this GridView gridView, string checkBoxId)
        {
            var checkedRows = from GridViewRow gridRow in gridView.Rows
                              where ((CheckBox)gridRow.FindControl(checkBoxId)).Checked
                              select gridRow;

            return checkedRows.ToList();
        }

        /// <summary>
        /// Busca o valor da célula do grid, passando como parâmetro o nome da coluna utilizado no parâmetro DataField.
        /// </summary>
        /// <param name="fieldName">Nome da Coluna</param>
        /// <returns></returns>
        public static int GetColumnIndexByName(this GridView grid, string dataFieldName)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                DataControlField field = grid.Columns[i];

                BoundField bfield = field as BoundField;

                if (bfield != null && bfield.DataField == dataFieldName)
                    return i;
            }
            return -1;
        }

        public static int? ToInt32(this string input)
        {
            int outValue;
            return Int32.TryParse(input, out outValue) ? (int?)outValue : null;
        }

        public static void Limpar(this TextBox txt)
        {
            txt.Text = string.Empty;
        }

        public static void Limpar(this ListControl lc)
        {
            lc.SelectedIndex = -1;
        }

        public static void Limpar(this GridView gv)
        {
            gv.DataSource = null;
            gv.DataBind();
        }

        public static void Limpar(this Control ctrl)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Limpar();
            else if (ctrl is ListControl)
                ((ListControl)ctrl).Limpar();
            else if (ctrl is GridView)
                ((GridView)ctrl).Limpar();

            foreach (Control child in ctrl.Controls)
            {
                child.Limpar();
            }
        }
    }
}