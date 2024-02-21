import * as angular from "angular";
import * as mx from "@labtagon/matrix42-workspace-management-types";

import CentralAdministrationHomeController from "./Controllers/CentralAdministrationHomeController";

require("./module.css");

window.mx.workspacesConfig.modules.add('CentralAdministration', { dependencies: ['ngMaterial'] });

angular.module('CentralAdministration')
    .controller("ca.HomeController", CentralAdministrationHomeController);