using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Input;

using System.Diagnostics;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MyDocking.NDock
{

    public class MyDockPanel :DockPanel
    {
        DockPanelItem centerPanel;
        DockPanelItem leftPanel;
        DockPanelItem rightPanel;
        DockPanelItem bottomPanel;
      

        TabControl centralTab;
        TabControl leftTab;
        TabControl rightTab;
        TabControl bottomTab;

        ObservableCollection<Document> _documents = new ObservableCollection<Document>();
        public ObservableCollection<Document> TabElements 
        { 
            set
            {
                _documents = value;
      //          _documents.CollectionChanged +=_documents_CollectionChanged;
            }
            get
            {
                return _documents;
            }
        }



        public MyDockPanel()
        {
          //  Children = new UIElementCollection(this, this);
            centralTab = new TabControl();
            leftTab = new TabControl();
            rightTab = new TabControl();
            bottomTab = new TabControl();
           // centralTab.Items.Add(new TabItem() { Header = "tab1" });
            
            centerPanel = new DockPanelItem(this,Dock.Top, true, centralTab);
           leftPanel = new DockPanelItem(this, Dock.Left, false, leftTab);
            rightPanel = new DockPanelItem(this, Dock.Right, false, rightTab);
            bottomPanel = new DockPanelItem(this, Dock.Bottom, false, bottomTab);
          

            Children.Add(leftPanel);
            Children.Add(rightPanel);     
            Children.Add(bottomPanel);
         
     

            Children.Add(centerPanel);
          
            SetDock(leftPanel, Dock.Left);
            SetDock(rightPanel, Dock.Right);
            SetDock(bottomPanel, Dock.Bottom);
         
           
            LastChildFill = true;

            MouseMove += MyDockPanel_MouseMove;

   
            TabElements.CollectionChanged += _documents_CollectionChanged;
            
       
        }

        private void _documents_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Document item = (e.NewItems[0] as Document);

                    switch(item.Dock)
                    {
                        case Dock.Top: centralTab.Items.Add(item.parentTab); break;
                        case Dock.Left: leftTab.Items.Add(item.parentTab); break;
                        case Dock.Right: rightTab.Items.Add(item.parentTab); break;
                        case Dock.Bottom: bottomTab.Items.Add(item.parentTab); break;
                    }
                    
                    break;
            }
          

        }

        private void MyDockPanel_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            leftPanel.OnParentMouseMove(sender, e);
            rightPanel.OnParentMouseMove(sender, e);
            bottomPanel.OnParentMouseMove(sender, e);
         
            //    Debug.WriteLine(e.GetPosition(this).X.ToString());
        }

        
    }

    //класс представляет собой док-панель, поддерживает масштабирование мышью и содержит оверлей
    public class DockPanelItem : Grid
    {
        Dock docking;
        Rectangle border;
        // UIElement _content;
        public object parent;
        public UIElement Content
        {
            set
            {
                Children.RemoveAt(0);
                if (value == null)
                    Children.Insert(0, new UIElement()); //Убрали элементы
                else
                    Children.Insert(0, value);
            }
            

            get { return Children[0]; }
        }

        bool _fill;
        public DockPanelItem(object parent, Dock place, bool fill, UIElement content)
        {
            this.parent = parent;
            this.Children.Add(content);
            _fill = fill;
            Content = content;
            docking = place;

            var overlay = new Rectangle();
            overlay.MouseEnter += Overlay_MouseEnter;
            overlay.MouseLeave += Overlay_MouseLeave;

            overlay.Fill = Brushes.Transparent;
            //только основной элемент и оверлей если это центральный элемент
            if (fill)
            {
         //       
            }
            else
            {
                switch (place)
                {
                    case Dock.Left:
                        ColumnDefinitions.Add(new ColumnDefinition() { Width = new System.Windows.GridLength(30) });
                        ColumnDefinitions.Add(new ColumnDefinition() { Width = new System.Windows.GridLength(0, System.Windows.GridUnitType.Auto) });

                        border = new Rectangle();
                        border.Fill = Brushes.White;
                        border.Width = 5;
                        border.Cursor = Cursors.SizeWE;

                        border.MouseDown += Border_MouseDown;

                        this.Children.Add(border);


                        SetColumn(content, 0);
                        SetColumn(border, 1);
                        break;
                    case Dock.Right:
                       
                        ColumnDefinitions.Add(new ColumnDefinition() { Width = new System.Windows.GridLength(5, System.Windows.GridUnitType.Auto) });
                        ColumnDefinitions.Add(new ColumnDefinition() { Width = new System.Windows.GridLength(30) });

                        border = new Rectangle();
                        border.Fill = Brushes.White;
                        border.Width = 5;
                        border.Cursor = Cursors.SizeWE;

                        border.MouseDown += Border_MouseDown;

                        this.Children.Add(border);


                        SetColumn(content, 1);
                        SetColumn(border, 0);
                        SetColumn(overlay, 1);
                        break;
                    case Dock.Top:
                        RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });
                        RowDefinitions.Add(new RowDefinition() { Height = new GridLength(5, GridUnitType.Auto) });

                  
                        border = new Rectangle();
                        border.Fill = Brushes.White;
                        border.Height = 5;
                        border.Cursor = Cursors.SizeNS;

                        border.MouseDown += Border_MouseDown;

                        this.Children.Add(border);


                        SetRow(content, 0);
                        SetRow(border, 1);
                        SetRow(overlay, 0);
                        break;
                    case Dock.Bottom:
                        RowDefinitions.Add(new RowDefinition() { Height = new GridLength(5, GridUnitType.Auto) });
                        RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });
                        


                        border = new Rectangle();
                        border.Fill = Brushes.White;
                        border.Height = 5;
                        border.Cursor = Cursors.SizeNS;

                        border.MouseDown += Border_MouseDown;

                        this.Children.Add(border);


                        SetRow(content, 1);
                        SetRow(border, 0);
                        SetRow(overlay, 1);
                        break;

                }
            }

            
          //  this.Children.Add(overlay);
            
       //     MouseMove += DockPanelItem_MouseMove;
            MouseUp += DockPanelItem_MouseUp;
        }

        private void DockPanelItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragBorder = false;

         //   throw new NotImplementedException();
        }

        Point startPoint;
        double startProperty;

        public void OnParentMouseMove(object sender, MouseEventArgs e)
        {
           
            if (!dragBorder || e.LeftButton == MouseButtonState.Released)
                return;

            
            double newProperty;
            switch (docking)
            {
                
                
                case Dock.Left:
                     newProperty = startProperty + e.GetPosition(sender as DockPanel).X - startPoint.X;

                    ColumnDefinitions[0].Width = new GridLength(newProperty>0? newProperty: 0);
                    break;

                case Dock.Right:
                    newProperty = startProperty - ( e.GetPosition(sender as DockPanel).X - startPoint.X);
                 
                    ColumnDefinitions[1].Width = new GridLength(newProperty > 0 ? newProperty : 0);
                    break;
                case Dock.Top:
                    newProperty = startProperty + e.GetPosition(sender as DockPanel).Y - startPoint.Y;
                    RowDefinitions[0].Height = new GridLength(newProperty > 0 ? newProperty : 0);
                    break;
                case Dock.Bottom:
                    newProperty = startProperty - (e.GetPosition(sender as DockPanel).Y - startPoint.Y);
                    RowDefinitions[1].Height = new GridLength(newProperty > 0 ? newProperty : 0);
                    break;
            }
        }


        bool dragBorder = false;
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragBorder = true;
            startPoint = e.GetPosition(parent as DockPanel);
            switch (docking)
            {
                case Dock.Left:
                    startProperty = ColumnDefinitions[0].Width.Value;
                    break;
                case Dock.Right:
                    startProperty = ColumnDefinitions[1].Width.Value;
                    break;
                case Dock.Top:
                    startProperty = RowDefinitions[0].Height.Value;
                    break;
                case Dock.Bottom:
                    startProperty = RowDefinitions[1].Height.Value;
                    break;
            }
        }

        private void Overlay_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = Brushes.Transparent;
           // throw new NotImplementedException();
        }

        private void Overlay_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = new SolidColorBrush(Color.FromArgb(60,96,128,255));
         //   throw new NotImplementedException();
        }
    }

    //содержимое панели 
    public class Document 
    {


        public TabItem parentTab = new TabItem();

        public Dock Dock { set; get; } = Dock.Top;

        string _header = "";
        public object Content
        {
            set
            {
                parentTab.Content = value;
            }
            get
            {
                return (object)parentTab.Content;
            }
        }

        public string Header
        {
            set
            {
                if (parentTab != null)
                {
                    parentTab.Header = value;
                }
                _header = value;

            }
            get
            {
                if (parentTab != null)
                    return (string)parentTab.Header;
                else
                    return _header;


            }
        }


     
      
       
    }

  
    
}
