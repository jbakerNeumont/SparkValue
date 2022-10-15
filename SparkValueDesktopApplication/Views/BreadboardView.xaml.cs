﻿using SparkValueDesktopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SparkValueDesktopApplication.Views
{
    /// <summary>
    /// Interaction logic for BreadboardView.xaml
    /// </summary>
    public partial class BreadboardView : UserControl
    {

        public static readonly DependencyProperty ComponentPlaceCommandProperty =
            DependencyProperty.Register("ComponentPlaceCommand", typeof(ICommand), typeof(BreadboardView), new PropertyMetadata(null));
        public ICommand ComponentPlaceCommand
        {
            get { return (ICommand)GetValue(ComponentPlaceCommandProperty); }
            set { SetValue(ComponentPlaceCommandProperty, value); }
        }

        public BreadboardView()
        {
            InitializeComponent();
        }

        private void Component_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                ComponentViewModel selectedComponent = null;
                foreach (var item in categoryList.Items)
                {
                    //UIElement element = (UIElement)categoryList.ItemContainerGenerator.ContainerFromItem(item);
                    ContentPresenter container = categoryList.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
                    container.ApplyTemplate();

                    Expander? expander = container.ContentTemplate.FindName("dropDown", container) as Expander;
                    ItemsControl? itemsControl = container.ContentTemplate.FindName("componentList", container) as ItemsControl;

                    if (selectedComponent != null) break;

                    if (expander != null && itemsControl != null && expander.IsExpanded)
                    {
                        if (itemsControl.Items.Count <= 0) break;
                        foreach (var component in itemsControl.Items)
                        {
                            if(component.GetType() == typeof(ComponentViewModel))
                            {
                                ComponentViewModel comp = component as ComponentViewModel;
                                Image targetImage = sender as Image;
                                if (comp?.Picture == targetImage?.Source)
                                {
                                    selectedComponent = comp;
                                    break;
                                }
                            }
                        }
                    }
                }
                Image image = sender as Image;
                image.Source = selectedComponent?.Picture;
                DragDrop.DoDragDrop((DependencyObject)sender, new DataObject(DataFormats.Serializable, (image, selectedComponent)), DragDropEffects.Move);
            }
        }

        private void breadboard_Drop(object sender, DragEventArgs e)
        {
            (Image, ComponentViewModel) data = ((Image, ComponentViewModel))e.Data.GetData(DataFormats.Serializable);

            if (ComponentPlaceCommand.CanExecute(ComponentPlaceCommand))
            {
                ComponentPlaceCommand.Execute(data.Item2);
            }
            
        }

        private void expander_DragLeave(object sender, DragEventArgs e)
        {
            (Image, ComponentViewModel) data = ((Image, ComponentViewModel))e.Data.GetData(DataFormats.Serializable);

            Grid parent = data.Item1.Parent as Grid;
            if (parent != null && parent.Children.Count > 0) parent.Children.RemoveAt(0);
            
        }

        private void breadboard_DragOver(object sender, DragEventArgs e)
        {
            (Image, ComponentViewModel) draggedData = ((Image, ComponentViewModel))e.Data.GetData(DataFormats.Serializable);

            Point dropPosition = e.GetPosition(breadboard);
            Canvas.SetLeft(draggedData.Item1, dropPosition.X);
            Canvas.SetTop(draggedData.Item1, dropPosition.Y);
            overlay.IsHitTestVisible = false;
            if (!breadboard.Children.Contains(draggedData.Item1))
            {
                breadboard.Children.Add(draggedData.Item1);
            }
        }
    }
}
