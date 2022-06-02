using System.Text;

namespace BlazorTextareaWasmDemo.Client.Pages
{
    public static class LorumIpsum
    {
        public static string Text1000() =>
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce finibus erat elit, sit amet hendrerit magna fringilla sed. Aliquam erat volutpat. 
Sed non aliquam elit, non porttitor dui. Ut sapien dolor, venenatis et risus quis, fermentum lacinia est. 
In sed tristique nulla. Nullam magna sem, volutpat vitae placerat in, convallis in neque. Sed aliquet libero nec magna vulputate imperdiet. Quisque efficitur a elit non fringilla. 

Curabitur lobortis odio eget justo lobortis elementum. Vivamus vestibulum ultrices nunc, eget cursus libero sollicitudin vitae. Vivamus dictum ipsum ac massa ultrices, dapibus eleifend massa commodo. 

Pellentesque a luctus, lobortis in dictum felis. Suspendisse elit enim, vehicula mattis enim rutrum ut. Nullam iaculis mi quis ipsum volutpat scelerisque.
Donec euismod, orci id porttitor accumsan, libero erat facilisis augue, ut elementum odio odio sed tellus.Aliquam erat volutpat.Praesent ante nibh, convallis ac placerat ac, pulvinar ut neque.In feugiat id.

".Replace("\r\n", "\n");

        public static string Text1000(int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(Text1000());
            }
            return sb.ToString();
        }
    }
}
