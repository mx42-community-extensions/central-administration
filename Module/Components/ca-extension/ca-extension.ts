import * as mx from "@labtagon/matrix42-workspace-management-types";
import * as angular from "angular";

export class ExtensionController implements angular.IController {
    static $inject = [
        '$window',
        '$scope',
        '$timeout'
    ]

    private extension: CentralAdministration.Contracts.DataContracts.Extension;

    constructor(
        private $window: ng.IWindowService,
        private $scope: ng.IScope,
        private $timeout: ng.ITimeoutService
    )
    {
   
    }
   
    public async $onInit() {


    };
}


const ExtensionComponent = {
    controller: ExtensionController,
    controllerAs: "vm",
    bindings: {
        "extension": "=",
    },
    template: require("ng-cache-loader?prefix=!./ca-extension.html")
} as ng.IComponentOptions;

export default ExtensionComponent;