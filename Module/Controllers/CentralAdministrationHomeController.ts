import * as mx from "@labtagon/matrix42-workspace-management-types";
import * as angular from "angular";

require("ng-cache-loader?prefix=!./ca-home.html");
export default class CentralAdministrationController implements angular.IController {
    static $inject = [
        '$window',
        '$scope',
        '$timeout',
        'mx.SolutionBuilderAgent.DialogOpenerService',
        'mx.shell.ActionExecutorService',
        'mx.shell.ActionManagerService',
        'mx.shell.EventService',
        "$injector"
    ]

    private loading: boolean = false;

    constructor(
        private $window: ng.IWindowService,
        private $scope: ng.IScope,
        private $timeout: ng.ITimeoutService,
        private dialogOpener: mx.SolutionBuilderAgent.DialogOpenerService,
        private actionExecutor: mx.shell.ActionExecutorService,
        private actionManager: mx.shell.ActionManagerService,
        private eventingService: mx.shell.EventService,
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
        //loading extensions
        await this.$timeout(2000);
        this.loading = false;
    }

    public async $onInit() {
        await this.refreshPageState();
    };
}