﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VGIS.Domain.BusinessRules;
using VGIS.Domain.Repositories;
using VGIS.Domain.Services;
using VGIS.Domain.Tools;

namespace VGIS.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Init data 
            // Init
            var gameSettingsRepo = new GameSettingsRepository($@"{Directory.GetCurrentDirectory()}\GameSettings\");
            var installationDirRepo = new InstallationDirectoriesRepository();
            var fileAndFolderRenamer = new FileAndFolderRenamer();
            var directoryBrowser = new DirectoryBrowser();
            var pathPatternTranslator = new PathPatternTranslator(directoryBrowser);
            
            //Init Service
            var introEdotionService = new IntroEditionService(gameSettingsRepo, installationDirRepo, fileAndFolderRenamer, pathPatternTranslator);

            //Load GUI
            var viewModel = new MainWindowViewModel(introEdotionService);
            var view = new MainWindow(viewModel);

            Application.Current.MainWindow = view;
            Application.Current.MainWindow.Show();
        }
    }
}
