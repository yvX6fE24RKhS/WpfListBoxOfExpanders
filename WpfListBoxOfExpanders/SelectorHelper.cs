using System.Windows;
using System.Windows.Controls.Primitives;

namespace WpfListBoxOfExpanders
{
   /// <summary>
   /// Реализует присоединенное свойство IsKeyboardFocusWithinSelectProperty
   /// </summary>
   /// <see href="https://www.cyberforum.ru/wpf-silverlight/thread3161988.html#post17273662"/>
   public static class SelectorHelper
   {
      public static bool GetIsKeyboardFocusWithinSelect(UIElement obj)
      {
         return (bool)obj.GetValue(IsKeyboardFocusWithinSelectProperty);
      }

      public static void SetIsKeyboardFocusWithinSelect(UIElement obj, bool value)
      {
         obj.SetValue(IsKeyboardFocusWithinSelectProperty, value);
      }

      // Using a DependencyProperty as the backing store for IsKeyboardFocusWithinSelect.  This enables animation, styling, binding, etc...
      // Использование DependencyProperty в качестве резервного хранилища для IsKeyboardFocusWithinSelect.
      // Это обеспечивает анимацию, стилизацию, привязку и т. д.
      public static readonly DependencyProperty IsKeyboardFocusWithinSelectProperty =
          DependencyProperty.RegisterAttached("IsKeyboardFocusWithinSelect",
                                              typeof(bool),
                                              typeof(SelectorHelper),
                                              new PropertyMetadata(false, OnIsKeyboardFocusWithinSelectChanged));

      private static void OnIsKeyboardFocusWithinSelectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         if (d is not UIElement ui)
            throw new NotImplementedException("Реализовано только для UIElement");

         if (true.Equals(e.NewValue))
         {
            ui.IsKeyboardFocusWithinChanged += OnIsKeyboardFocusWithinChanged;
         }
         else
         {
            ui.IsKeyboardFocusWithinChanged -= OnIsKeyboardFocusWithinChanged;
         }

      }

      private static readonly object trueBox = true;
      private static void OnIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
      {
         UIElement ui = (UIElement)sender;

         if (ui.IsKeyboardFocusWithin)
         {
            ui.SetValue(Selector.IsSelectedProperty, trueBox);
         }
      }
   }
}