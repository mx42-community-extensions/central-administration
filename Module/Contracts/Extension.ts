namespace CentralAdministration.Contracts.DataContracts {
    export class Extension {
        public id: string;
        public license: License;
        public package: Package;
    }

    export class Package {
        public version: string;
        public lastUpdatedDate?: Date | null;
        public installedDate?: Date | null;
        public name: string;
        public description: string;
        public updatedBy: string;
    }
}
