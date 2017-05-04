using GalaSoft.MvvmLight.CommandWpf;
using SDP.CSharp.Excercise4.AnonymousTypesAndLambdas.Model;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace SDP.CSharp.Excercise4.AnonymousTypesAndLambdas.ViewModel
{
    /// <summary>
    /// Represents a view model for tree view excercise
    /// </summary>
    class TreeViewViewModel : INotifyPropertyChanged
    {
        private PeopleSource mSource;
        private GroupingSelection mGroupingType;

        /// <summary>
        /// Informs subscribers that a propery of this intance was changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Creates new instance of TreeViewViewModel class
        /// </summary>
        public TreeViewViewModel()
        {
            // instantiate data source
            mSource = new PeopleSource();

            // instantiate command
            GroupingSelectionCommand = new RelayCommand<GroupingSelection>(selectedGroup => 
            {
                // save selected grouping mode
                mGroupingType = selectedGroup;

                // inform subscribers about the DataSource property change
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DataSource"));
            });
        }

        /// <summary>
        /// Gets or sets a GroupingSelection command
        /// </summary>
        public RelayCommand<GroupingSelection> GroupingSelectionCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets non-generic IEnumerable instance which is a data source for TreeView control
        /// </summary>
        public IEnumerable DataSource
        {
            get
            {
                // check grouping mode
                switch (mGroupingType)
                {
                    case GroupingSelection.ByCity:
                        return from p in mSource
                               group p by p.City into g
                               select new
                               {
                                   Name = g.Key,
                                   SubItems = from groupItem in g
                                              select new
                                              {
                                                  Name = groupItem.Name
                                              }
                               };

                    case GroupingSelection.ByDate:
                        return from p in mSource
                               group p by p.SignInDate into g
                               select new
                               {
                                   Name = g.Key,
                                   SubItems = from groupItem in g
                                              select new
                                              {
                                                  Name = groupItem.Name
                                              }
                               };

                    case GroupingSelection.ByCompany:
                        return from p in mSource
                               group p by p.Company into g
                               select new
                               {
                                   Name = g.Key,
                                   SubItems = from groupItem in g
                                              select new
                                              {
                                                  Name = groupItem.Name
                                              }
                               };

                        // TODO: Excercise 1:
                        // TODO: Add functionality "Group By Number of vowels in Person's name"
                        //       Add proper entry in enum, UI and proper LINQ code inside DataSource property here
                }

                // no grouping, return just a list of names
                return from p in mSource
                       select new
                       {
                           Name = p.Name
                       };
            }
        }
    }
}
