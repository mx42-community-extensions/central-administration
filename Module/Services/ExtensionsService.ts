import * as mx from "@labtagon/matrix42-workspace-management-types"
import ExtensionRepository from "./ExtensionRepository";

export default class ExtensionsService {

    static $inject = ["ca.ExtensionRepository"] as string[];

    private extensions: CentralAdministration.Contracts.DataContracts.Extension[];

    constructor(private extensionRepository: ExtensionRepository) {

    }

    public async loadExtensions(): Promise<CentralAdministration.Contracts.DataContracts.Extension[]> {
        return (this.extensions = await this.extensionRepository.getExtensions());
    }

}