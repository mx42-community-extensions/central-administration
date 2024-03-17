import * as mx from "@labtagon/matrix42-workspace-management-types"

export default class ExtensionRepository {
    static $inject = ["mx.SolutionBuilderAgent.Http"] as string[];

    constructor(
        private $http: mx.SolutionBuilderAgent.Http
    ) {

    }

    public getExtensions(): Promise<CentralAdministration.Contracts.DataContracts.Extension[]> {
        return this.$http.get<CentralAdministration.Contracts.DataContracts.Extension[]>("api/CentralAdministration/Extensions");
    }
}