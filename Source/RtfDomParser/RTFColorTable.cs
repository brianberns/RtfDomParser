/*
 * 
 *   DCSoft RTF DOM v1.0
 *   Author : Yuan yong fu.
 *   Email  : yyf9989@hotmail.com
 *   blog site:http://www.cnblogs.com/xdesigner.
 * 
 */



using System.Collections ;
using RtfDomParser.Utils;
using SixLabors.ImageSharp;

namespace RtfDomParser
{
	/// <summary>
	/// rtf color table
	/// </summary>
    [System.Diagnostics.DebuggerDisplay("Count={Count}")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(RTFInstanceDebugView))]
	public class RTFColorTable
	{
		/// <summary>
		/// initialize instance
		/// </summary>
		public RTFColorTable()
		{
		}

		private ArrayList myItems = new ArrayList();
		/// <summary>
		/// get color at special index
		/// </summary>
		public Color this[ int index ]
		{
			get
            {
                return ( Color ) myItems[ index ] ;
            }
		}

		/// <summary>
		/// get color at special index , if index out of range , return default color
		/// </summary>
		/// <param name="index">index</param>
		/// <param name="DefaultValue">default value</param>
		/// <returns>color value</returns>
		public Color GetColor( int index , Color DefaultValue )
		{
			index -- ;
            if (index >= 0 && index < myItems.Count)
            {
                return (Color)myItems[index];
            }
            else
            {
                return DefaultValue;
            }
		}

        private bool bolCheckValueExistWhenAdd = true ;
        /// <summary>
        /// check color value exist when add color to list
        /// </summary>
        public bool CheckValueExistWhenAdd
        {
            get
            {
                return bolCheckValueExistWhenAdd; 
            }
            set
            {
                bolCheckValueExistWhenAdd = value; 
            }
        }

		/// <summary>
		/// add color to list
		/// </summary>
		/// <param name="c">new color value</param>
		public void Add( Color c )
		{
			if( c == ImageTools.ColorEmpty )
				return ;

            var A = c.GetAlpha();

            if ( A == 0 )
				return ;
			
			if( A != 255 )
			{
				c = c.WithAlpha(255);
			}

            if (bolCheckValueExistWhenAdd)
            {
                if (IndexOf(c) < 0)
                {
                    myItems.Add(c);
                }
            }
            else
            {
                myItems.Add(c);
            }
		}
		/// <summary>
		/// delete special color
		/// </summary>
		/// <param name="c">color value</param>
		public void Remove( Color c )
		{
			int index = IndexOf( c );
			if( index >= 0 )
				myItems.RemoveAt( index );
		}
		/// <summary>
		/// get color index
		/// </summary>
		/// <param name="c">color</param>
		/// <returns>index , if not found , return -1</returns>
		public int IndexOf( Color c )
        {
            var A = c.GetAlpha();

            if (A == 0)
            {
                return -1;
            }
			if( A != 255 )
			{
				c = c.WithAlpha(255);
			}
            for (int iCount = 0; iCount < myItems.Count; iCount++)
            {
                Color color = (Color)myItems[iCount];
                if (color.ToArgb() == c.ToArgb())
                {
                    return iCount;
                }
            }
			return -1 ;
		}
		/// <summary>
		/// ����б�
		/// </summary>
		public void Clear()
		{
			myItems.Clear();
		}
		/// <summary>
		/// Ԫ�ظ���
		/// </summary>
		public int Count
		{
			get{ return myItems.Count ; }
		}

		/// <summary>
		/// �����ɫ��
		/// </summary>
		/// <param name="writer">RTF�ĵ���д��</param>
		public void Write( RTFWriter writer )
		{
			writer.WriteStartGroup();
			writer.WriteKeyword( RTFConsts._colortbl );
			writer.WriteRaw(";");
			for( int iCount = 0 ; iCount < myItems.Count ; iCount ++ )
			{
				Color ic = ( Color ) myItems[ iCount ] ;
                var c = ic.Extract();
				writer.WriteKeyword( "red" + c.R );
				writer.WriteKeyword( "green" + c.G );
				writer.WriteKeyword( "blue" + c.B );
				writer.WriteRaw(";");
			}
			writer.WriteEndGroup();
		}

        /// <summary>
        /// ���ƶ���
        /// </summary>
        /// <returns>����Ʒ</returns>
        public RTFColorTable Clone()
        {
            RTFColorTable table = new RTFColorTable();
            for (int iCount = 0; iCount < myItems.Count; iCount++)
            {
                Color c = ( Color ) myItems[ iCount ] ;
                table.myItems.Add(c);
            }
            return table;
        }
    }
}