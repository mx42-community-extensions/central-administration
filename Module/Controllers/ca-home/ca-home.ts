import * as mx from "@labtagon/matrix42-workspace-management-types";
import * as angular from "angular";
import ExtensionRepository from "../../Services/ExtensionRepository";
import ExtensionsService from "../../Services/ExtensionsService";

require("ng-cache-loader?prefix=!./ca-home.html");

class Category {
    TranslationKey: string
    Value: number
}

export default class CentralAdministrationController implements angular.IController {
    static $inject = [
        '$window',
        "mx.internationalization",
        '$scope',
        '$timeout',
        'mx.SolutionBuilderAgent.DialogOpenerService',
        'mx.shell.ActionExecutorService',
        'mx.shell.ActionManagerService',
        'mx.shell.EventService',
        'ca.ExtensionRepository',
        'ca.ExtensionsService',
        "$injector" 
    ]

    private loading: boolean = false;
    private extensions: CentralAdministration.Contracts.DataContracts.Extension[];

    private categories: Category[] = [
        { TranslationKey: "ca.home.categories.controls",                 Value: 1 },
        { TranslationKey: "ca.home.categories.connectors",               Value: 2 },
        { TranslationKey: "ca.home.categories.workflowactivities",       Value: 3 },
        { TranslationKey: "ca.home.categories.processtools",             Value: 4 }
    ] 

    constructor(
        private $window: ng.IWindowService,
        private i18n: mx.internationalization,
        private $scope: ng.IScope,
        private $timeout: ng.ITimeoutService,
        private dialogOpener: mx.SolutionBuilderAgent.DialogOpenerService,
        private actionExecutor: mx.shell.ActionExecutorService,
        private actionManager: mx.shell.ActionManagerService,
        private eventingService: mx.shell.EventService,
        private extensionRepository: ExtensionRepository,
        private extensionsService: ExtensionsService,
        private $injector: ng.auto.IInjectorService)
    {
        let actionsContext = new mx.shell.ActionsContext([], [], mx.shell.ActionUiZone.SearchPage);
        actionsContext.extraActions = null;
        actionsContext.hideActions = [];
        this.eventingService.dispatchEvent(mx.shell.EventCodes.ActionsContextChanged, actionsContext);

        this.eventingService.subscribeGlobal(mx.shell.EventCodes.WizardClose, async (event, data) => {
            await this.refreshPageState();
        });

        this.eventingService.subscribeGlobal(mx.shell.EventCodes.SidePanelViewClosed, async (event, data) => {
            await this.refreshPageState();
        });
    }

    private async refreshPageState() {
        this.loading = true;
        this.extensions = await this.extensionsService.loadExtensions();
        this.loading = false;
    }

  
    public async launchSetup() {
        let setupAction = (await this.actionManager.getAllActions()).find(a => a.name == "ca-setup");

        this.actionExecutor
            .execute(setupAction,
                [
                    {
                        _id: "859E5D52-CFE9-402B-8CB2-68CC6437D096",
                        _displayName: "Central Administration",
                        _type: "CAExtensionTypeCentralAdministration"
                    }
                ]
            )

    }


    public async $onInit() {
        await this.refreshPageState();
    };
}