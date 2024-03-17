namespace CentralAdministration.Contracts.DataContracts {
    export enum LicenseMetric {
        User = 0,
        System = 1,
        Machine = 2
    }

    export class License {
        public extensionId: string;
        public issuerId: string;
        public metric: LicenseMetric;
        public count: number;
        public validUntil?: Date | null;
        public validFrom?: Date | null;
        public components: ComponentLicense[];
    }

    export class ComponentLicense {
        public name: string;
        public componentId: string;
        public validUntil?: Date | null;
        public validFrom?: Date | null;
    }
}
