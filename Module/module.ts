import * as angular from "angular";
import * as mx from "@labtagon/matrix42-workspace-management-types";

import CentralAdministrationHomeController from "./Controllers/ca-home/ca-home";
import ExtensionRepository from "./Services/ExtensionRepository";
import ExtensionComponent from "./Components/ca-extension/ca-extension";
import ExtensionsService from "./Services/ExtensionsService";

require("./module.css");

window.mx.workspacesConfig.modules.add('CentralAdministration', { dependencies: ['ngMaterial'] });

angular.module('CentralAdministration')
    .service("ca.ExtensionRepository", ExtensionRepository)
    .service("ca.ExtensionsService", ExtensionsService)
    .component("caExtension", ExtensionComponent)
    .controller("ca.HomeController", CentralAdministrationHomeController);