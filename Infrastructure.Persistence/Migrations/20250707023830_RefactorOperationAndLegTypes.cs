using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorOperationAndLegTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("024f8c86-6909-48cd-8d73-c3e459d3179d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("026f86b5-3c88-4169-99d4-95850879e87a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("03a49e55-04e6-48bc-9a7c-a8f41962815c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("03c82b37-b491-4eda-94f9-cd674fdc9e4c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("05e06868-8f76-4793-95e8-2c712cc0894a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("07f88392-d02d-4879-9cf0-38bf7ee153f1"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0d8f3b42-976d-486b-bf2a-caa7b361174d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0dfdf499-d77d-414f-b124-a9f61cc43302"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0e3a43c3-ced3-44c9-8eff-92125f69f84e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("108eb812-5056-47f4-bd4d-3e8795488ccd"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("12061183-c46c-4264-a26d-6089ed262931"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1270444d-4246-489e-89af-cae50d2413b9"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("12836d29-5bd7-44be-9899-ea5b62deafda"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("12a45ab9-0166-4195-94cb-d61ae5c646bc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("14ecd1a3-fc23-459b-95fa-d96f256514f6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("184cfbd0-36c3-4796-b42f-51372a39fcab"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("18bf8d2c-8c92-473e-a8fe-7db0691e2753"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("199154c4-eb9e-4916-bd4c-f69025e1ad5e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1997c794-2098-483c-87bf-c0b6272cc1de"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1ca7f042-fa02-4c69-8609-59ab3de4e87d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1dd71a42-4b2e-4b4c-b6ba-328c6d724473"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("20a4575e-5819-4fad-ae8a-d91eaa9a005f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2193cc16-f96b-414e-8bf9-d52899fd199e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("21e1ce6e-c52c-490c-9714-e45b156a1540"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2227b150-7379-4554-9e06-8b0a00829ec0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("24a133df-c52c-48b9-ae6b-f912c3217c78"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("25676d7f-2101-4485-bbd9-e9aa10fc13e5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2658e8c3-77a2-4462-b3a8-4527dd2ffc67"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("282e94e2-ecea-4af5-8ca8-b4aa510a9eb0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("29201e8d-21f4-4757-8e3e-769734f488f2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2bb8b9a0-9c95-478e-9fc7-77ca07bf67a1"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2d87129c-96fc-45bb-bfd6-a713ab996c23"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2fa50609-3d49-415a-8165-cfb41dcdd5bc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2fdaea83-9f93-4e42-95d9-8a4a284541de"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("32b49394-032e-4039-b3fb-ec74e90e651e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("330d6d95-bd76-4261-b45c-757be4c171d0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("334847cd-724e-4658-8651-ad317a79f032"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("33d43655-d8a7-494e-b45c-1a8c86b74cc4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("342ab7b7-b682-4341-94c1-c98dd7a76aa4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("34ada21d-ac91-428b-a22b-a45b304132fa"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("34c46ac5-fb63-4173-9959-ebd39118890f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("39d35c6e-ad87-4b94-8d2f-ad603f1fbd8d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3b136058-452b-4964-abac-045bb7c9be42"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3f14e688-cf72-43d2-b4f5-7e264a3059f7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("455b6463-ae97-4c8e-b76e-0e7fe6695be7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("457838d7-4434-46c8-a407-8e2f1f7e844f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("49f1ec15-aab3-4b87-af58-ae2867b05582"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4a8d05ff-e55f-4f4b-83ff-bd1eb087e155"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4c99428e-15d2-4a26-814e-df0485fe2ba6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4cee1848-ce24-4a1e-b984-b8e272059386"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4eb6fd4a-5770-4d16-b4f1-dec85ded9455"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("51407e6b-b022-4743-a29a-6720956fa82e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("53346a1b-ff62-42ba-948c-45f2a7f44bee"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("53c24d9c-86a2-408c-aa49-ae078e9ab5fc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("55dc8d16-d3dd-4d64-86c0-ac1cee1d5fd9"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("57e36279-d09f-4d46-8d51-aab67f5a8310"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("595ea6bb-b268-492f-a17d-2529f7480cca"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5a1f0ab5-2b7c-4ef4-a202-dab1c23036f0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5d3ef524-0b65-4f94-bd5c-96a7752e44bf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5dbbbf94-0e92-4590-93c5-4505863ca5f2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5ff97503-b02f-4270-8969-a9dea0e0ccaf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6194b501-6c22-4f3f-ba76-1a8f5d1b7229"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("61de6cb4-9b1a-45fd-a9bd-47a56617e718"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("64143c05-c227-46bf-b4e9-b50e23dac42a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6469b582-f146-4e4e-8a70-0abe613ee07d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("647912a6-4d43-46c7-9b53-9888c005f4b6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("663aed05-3efa-4e23-9add-acae97edfde7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("66c146e3-808d-4e5d-80aa-c44018cb50eb"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("691b6fe9-d770-4df5-96f0-1c1ff4096467"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6a01b72f-8bdd-43a7-bdec-43165a8338f0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6a2d7d2a-8ee5-4682-aefe-f81089b81264"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6b6321de-7fae-4a0f-97e6-30f4c29c969e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6c570f89-6b79-442b-87ce-6f08d38faae8"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6e63c4ec-68df-44b9-bd5e-24c150470923"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("71e7733a-9349-4c4f-91cd-dd8ac062b989"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7a21fb6d-2d54-41e8-a71c-59d82a49b807"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7b171f95-97f2-4312-9a7b-3af40df2b0ad"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7be1726b-498d-4445-ac9f-a45fb2cac47e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7d5fbafc-964d-4088-be3a-45bc28161d06"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7dbd0cf4-88b5-4d63-9ace-c40b5457e17f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7e29f768-a561-43f2-b142-31096247c127"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("8039eeac-40fa-47cf-bb6b-3b80a8aaed1d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("814337ea-257e-4eff-9b70-77c6241c968e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("82947a9e-85bd-4c13-a609-080ed08c29f6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("85458e9d-d3fb-4324-8d5f-37ea3b35de79"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("85d3c698-3004-4698-b8d8-0791d8ffe16a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("8a05b642-daf9-491f-9069-57b0950d0255"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("8f4a80c3-c44b-464c-abc2-a6b59acbd735"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("8fe8d78c-1659-4a13-a5e7-8e609d85e871"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("91afd8a5-2ebe-43bc-b2d0-f7305ece6942"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("946aea29-e85a-4405-8aff-326df580abdb"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("94e17a33-d71c-4b35-89bb-db2f5942d7c1"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9c443b6d-a3e9-4a14-97e8-9844d907625a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9d7b7e3e-865c-41c7-8e89-f293931064b1"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9dff6f64-147f-4d30-a16f-c8fd6e17c0e2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9e962372-1faf-4058-a26d-b2650cb9f1ae"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9f99abf3-a0f1-438e-8bd4-6f4fe2e4b348"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9fb13e5a-df0b-40f5-b04f-c9007314131c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9fd52c0c-91e2-478b-9d2c-49bed0142057"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a18aa9b9-42ed-4a33-9c6c-905b8c41f3e6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a1f73f99-f262-413b-91c7-2b9434269fe7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a5647e0e-4afe-4ab0-ba46-14a5946c4d43"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a788cbec-91b6-4926-9ce4-23829fb93c22"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a930e6eb-2e00-4f07-b81d-e3cc93294bb5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("accb3d3f-9427-4f5b-ad55-75cbe5377186"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b0383f66-0007-496a-9d56-a668121a1310"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b07afbf6-d542-45fb-9426-04fa7ec8b051"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b1a794ce-ad5f-4d7f-91a2-819b1dd5e756"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b6c97579-8d54-4883-9d8c-5060443ec822"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b7eb2fab-df0f-4d01-a59e-04375257610c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b906a6c3-d805-428c-9f7e-9044a0c264b0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("bc6b3a64-1729-4755-bf55-f912269c9a6f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("be8b0477-748b-454b-9dee-4a03af13b079"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c1142a11-84bf-4be5-b83c-2b3ee6e405d5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c15412f6-7dec-43c8-ae41-79e83a9b118c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c22d2e2e-bf37-4cac-9b1c-f5571a559d97"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c2447cad-09cd-4d88-8ee6-fad1bf6439db"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c4140e31-efb7-49a2-94b4-9bcb999c2d7b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c7e16a4e-bf28-4e1d-9b26-b59ae6ba596b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c85bb462-c65b-4ebf-b348-f862f3cb4582"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c88119b8-fa8f-4232-b970-377e155104a5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c88e8959-76e6-4bc6-a4ae-1cc4a49b2711"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c89e26f6-1910-4734-a225-b179f950b42f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c92098b2-ba07-4aff-8b7b-52a5c0518c3b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c9df998b-365a-45e1-a54d-cab06e00ce1f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ca036578-a1a9-4449-8c11-3f0735f1ce96"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("cf37decf-2f5f-4f86-8a88-ee20a2b41150"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d0c9b454-2b6d-43bd-b1fb-1b23faeddc6f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d1c48450-ed21-4672-8ebf-e67b27baf038"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d1d9219b-d1e8-42e4-a9a4-3b1e6885890d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d1e9bb46-2643-4818-b47d-391cef92ffed"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d3cb4a85-0a91-4981-b460-9cd0b303821a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d3d7342b-a4aa-4832-b082-bb95f1b3c9c1"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d5a778db-61e5-4fc0-864c-0f3b45985afa"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d5e3b831-e600-4a7e-95eb-cbc87199a32b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("dcdd88a5-afc6-48da-9c18-3fe19a16b3a0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ddc37a97-9fe6-45dd-99be-601a9d59daa2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e4799e8d-87d5-4139-9686-5549c64be7b8"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e4c5709d-1598-4aa5-997b-557934e63b7a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e4d2065d-9c41-4132-bf08-e992caa58ec4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e74a4a65-f4fb-45b4-a5e2-065eacd13961"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e7a9a8f3-0bdb-45ba-a858-34b3bf79d305"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e9456e82-e049-4be6-8747-a68bc46382d0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f1fadfbe-51d5-49fb-85e0-504ae550bdd0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f5e8f9b7-a142-4892-a71f-d8e3f8646d5f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f7219f13-1120-4c81-b058-2ac8b09eb06a"));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TransactionLegs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Operations",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Operations",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "AssetClass",
                table: "Assets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetClass", "CountryCode", "Industry", "IsCustom", "Name", "Sector", "Ticker", "UserId" },
                values: new object[,]
                {
                    { new Guid("011bf9f2-19ac-4e0f-8ab0-7ae450011d39"), "Cash", null, null, false, "Zambian Kwacha", null, "ZMW", null },
                    { new Guid("016853d1-a20d-40d9-89b0-8f9223d817dc"), "Cash", null, null, false, "Mozambican Metical", null, "MZN", null },
                    { new Guid("039fe71b-dc81-4410-9491-52dd39481b9c"), "Cash", null, null, false, "Ghanaian Cedi", null, "GHS", null },
                    { new Guid("04133db8-dac2-49b5-b1c6-e01498e55dab"), "Cash", null, null, false, "Ethiopian Birr", null, "ETB", null },
                    { new Guid("04425aa8-2b84-4068-8afc-fb8d4422bd64"), "Cash", null, null, false, "Cayman Islands Dollar", null, "KYD", null },
                    { new Guid("051a2dc8-be73-4ca5-8b9c-abf89c330e1d"), "Cash", null, null, false, "Serbian Dinar", null, "RSD", null },
                    { new Guid("0757324f-a547-4cfa-8f51-076ec2cd46bf"), "Cash", null, null, false, "Lesotho Loti", null, "LSL", null },
                    { new Guid("0ac2b441-37ca-4763-aaec-c42f48e2714d"), "Cash", null, null, false, "Thai Baht", null, "THB", null },
                    { new Guid("0be14c9b-c1b5-482e-bd34-88dd1fa04470"), "Cash", null, null, false, "Comorian Franc", null, "KMF", null },
                    { new Guid("0c0dbd88-5565-45e7-9281-c37fab543c12"), "Cash", null, null, false, "Mexican Peso", null, "MXN", null },
                    { new Guid("0cc652b9-0848-4056-9f67-b045ae3dd704"), "Cash", null, null, false, "Dominican Peso", null, "DOP", null },
                    { new Guid("0ed1b0fc-27a3-4af7-b220-b02423122854"), "Cash", null, null, false, "Trinidad and Tobago Dollar", null, "TTD", null },
                    { new Guid("100b0b5d-f9f9-427e-b6ce-9490f751ed00"), "Cash", null, null, false, "Macanese Pataca", null, "MOP", null },
                    { new Guid("104cf31a-7608-4183-b336-448851de2c20"), "Cash", null, null, false, "Malaysian Ringgit", null, "MYR", null },
                    { new Guid("14f8a913-391c-4eb9-8b3f-d9ff79419922"), "Cash", null, null, false, "Swazi Lilangeni", null, "SZL", null },
                    { new Guid("163675aa-8a0d-4edd-9299-3ecfb18863b3"), "Cash", null, null, false, "Falkland Islands Pound", null, "FKP", null },
                    { new Guid("18ac3af6-a364-423c-88ed-5c97e9ebaa47"), "Cash", null, null, false, "Malagasy Ariary", null, "MGA", null },
                    { new Guid("190481d0-49c4-4874-b708-87050e968608"), "Cash", null, null, false, "Macedonian Denar", null, "MKD", null },
                    { new Guid("1ad046d8-6229-45a7-8eab-b5f726c5c588"), "Cash", null, null, false, "Jordanian Dinar", null, "JOD", null },
                    { new Guid("1bec1473-f447-4e6b-ba7d-c1900863efa5"), "Cash", null, null, false, "Cape Verdean Escudo", null, "CVE", null },
                    { new Guid("1e39ab48-e189-43f9-b33c-057bdadb5213"), "Cash", null, null, false, "Kuwaiti Dinar", null, "KWD", null },
                    { new Guid("20531207-647d-418a-b73c-70cff4b02863"), "Cash", null, null, false, "Botswana Pula", null, "BWP", null },
                    { new Guid("20f5ffa3-082a-467e-bdf9-e03e23b1d7f7"), "Cash", null, null, false, "Surinamese Dollar", null, "SRD", null },
                    { new Guid("29ce6769-6bf9-4922-ac58-3ad21cc0a3c4"), "Cash", null, null, false, "Indonesian Rupiah", null, "IDR", null },
                    { new Guid("2a092769-62f9-4dca-86a2-59d3d2953d4d"), "Cash", null, null, false, "Lebanese Pound", null, "LBP", null },
                    { new Guid("322ac18b-bf6f-40fe-9190-139b7d4de83a"), "Cash", null, null, false, "Omani Rial", null, "OMR", null },
                    { new Guid("33638d97-d492-4d21-8090-0f17fcf7618b"), "Cash", null, null, false, "Bhutanese Ngultrum", null, "BTN", null },
                    { new Guid("34563c3f-a91e-49b4-b3af-37a58c93f452"), "Cash", null, null, false, "Sri Lankan Rupee", null, "LKR", null },
                    { new Guid("3553faec-0c2a-441b-a01e-8ce54e6042d0"), "Cash", null, null, false, "Cambodian Riel", null, "KHR", null },
                    { new Guid("35aba6c3-b9bc-4198-a8ea-9b77a04797da"), "Cash", null, null, false, "Lao Kip", null, "LAK", null },
                    { new Guid("35d63400-d1cd-4c00-adc9-0d64d396e534"), "Cash", null, null, false, "Sierra Leonean Leone", null, "SLE", null },
                    { new Guid("3696a040-2efa-4b33-9975-cf1d24c5aa16"), "Cash", null, null, false, "Danish Krone", null, "DKK", null },
                    { new Guid("3a0b2c69-5c37-4fc4-b104-45dcd7c1bb0b"), "Cash", null, null, false, "Swiss Franc", null, "CHF", null },
                    { new Guid("3d43f193-d370-43ed-9d53-1199214c8e43"), "Cash", null, null, false, "Ugandan Shilling", null, "UGX", null },
                    { new Guid("3f2b3bc5-2f85-4593-abef-56038358305e"), "Cash", null, null, false, "South Korean Won", null, "KRW", null },
                    { new Guid("4052ae6c-da65-435b-b808-f5edef965c50"), "Cash", null, null, false, "Russian Ruble", null, "RUB", null },
                    { new Guid("40571b4f-291f-408f-b93b-3ecdc2e72ea3"), "Cash", null, null, false, "Peruvian Sol", null, "PEN", null },
                    { new Guid("40e5a52b-01bd-4264-a05c-9b3e59f2e989"), "Cash", null, null, false, "Angolan Kwanza", null, "AOA", null },
                    { new Guid("42e6af7f-774d-46c7-a17b-54d2e9ea844c"), "Cash", null, null, false, "Haitian Gourde", null, "HTG", null },
                    { new Guid("43fb8d35-e60a-4249-b330-f58f6589bf49"), "Cash", null, null, false, "Tajikistani Somoni", null, "TJS", null },
                    { new Guid("45af5a4b-d11c-4758-b7d9-523d37281773"), "Cash", null, null, false, "Australian Dollar", null, "AUD", null },
                    { new Guid("46b04247-7109-4cf4-8f84-521bd3e0e08c"), "Cash", null, null, false, "Bosnia and Herzegovina Convertible Mark", null, "BAM", null },
                    { new Guid("4a0e927d-8a55-43a2-a2ca-bfcab9e2c5a8"), "Cash", null, null, false, "Aruban Florin", null, "AWG", null },
                    { new Guid("4ad2f770-cd8a-44ab-8f9f-4a3d1efd5586"), "Cash", null, null, false, "North Korean Won", null, "KPW", null },
                    { new Guid("4d1f12b3-df31-40b4-84f2-1784956a3af9"), "Cash", null, null, false, "Armenian Dram", null, "AMD", null },
                    { new Guid("4e31bb57-33ca-47ce-a114-0709cb8563b5"), "Cash", null, null, false, "Bahraini Dinar", null, "BHD", null },
                    { new Guid("4ed3d4c2-9b5c-4a91-83a2-2bc6dde2b5c5"), "Cash", null, null, false, "Nicaraguan Córdoba", null, "NIO", null },
                    { new Guid("4f9df6ee-dccd-456d-885c-cbdb55af9dcc"), "Cash", null, null, false, "Netherlands Antillean Guilder", null, "ANG", null },
                    { new Guid("5127a26d-c355-4530-9ecd-a89b67fd4522"), "Cash", null, null, false, "Afghan Afghani", null, "AFN", null },
                    { new Guid("54e59f4e-649d-46fe-8904-0f18ce017c4a"), "Cash", null, null, false, "Indian Rupee", null, "INR", null },
                    { new Guid("560bca24-a063-43c3-ac53-473633820ce6"), "Cash", null, null, false, "Albanian Lek", null, "ALL", null },
                    { new Guid("5714346e-efde-4eea-9b9d-14c0267b75ce"), "Cash", null, null, false, "CFP Franc", null, "XPF", null },
                    { new Guid("5bee2db3-1b18-4694-b5f0-459a87a6097c"), "Cash", null, null, false, "Eritrean Nakfa", null, "ERN", null },
                    { new Guid("60a959de-eab6-49db-90ed-10ec0970f944"), "Cash", null, null, false, "Azerbaijani Manat", null, "AZN", null },
                    { new Guid("61c59eb4-6e91-4057-9b87-dc8d3d6def2a"), "Cash", null, null, false, "East Caribbean Dollar", null, "XCD", null },
                    { new Guid("628de140-d182-4621-8d31-cb467d2003e5"), "Cash", null, null, false, "Canadian Dollar", null, "CAD", null },
                    { new Guid("63febbff-3242-4874-9c65-ccba0a1d873d"), "Cash", null, null, false, "Djiboutian Franc", null, "DJF", null },
                    { new Guid("65bb4191-52ff-4c1d-ad87-b79e1ce2eca7"), "Cash", null, null, false, "Bulgarian Lev", null, "BGN", null },
                    { new Guid("664e5334-e253-4c43-96d7-0785ccd56960"), "Cash", null, null, false, "Congolese Franc", null, "CDF", null },
                    { new Guid("66f539b7-551c-44e3-bc0f-18d5bcbd3f4d"), "Cash", null, null, false, "Costa Rican Colón", null, "CRC", null },
                    { new Guid("6b35e375-0bf3-4388-a24a-953e82b9a296"), "Cash", null, null, false, "Yemeni Rial", null, "YER", null },
                    { new Guid("6b6d7b91-5dc2-4c5d-9a53-0f3e0f869b94"), "Cash", null, null, false, "Swedish Krona", null, "SEK", null },
                    { new Guid("6c54ee8c-6af1-4e1f-bfeb-7898cd39de99"), "Cash", null, null, false, "Turkish Lira", null, "TRY", null },
                    { new Guid("6e47ac3b-258e-4326-9fe7-632ccd04fa32"), "Cash", null, null, false, "Tanzanian Shilling", null, "TZS", null },
                    { new Guid("702af8bc-81c5-4982-89f5-20eb73c996c2"), "Cash", null, null, false, "UAE Dirham", null, "AED", null },
                    { new Guid("705ed296-9f28-4e1a-b28d-49921524bd16"), "Cash", null, null, false, "Nepalese Rupee", null, "NPR", null },
                    { new Guid("73fabb4b-df49-4697-8f78-a275480c95cc"), "Cash", null, null, false, "Taiwan Dollar", null, "TWD", null },
                    { new Guid("74fd7619-1182-4cc1-a016-56e1d9ab9974"), "Cash", null, null, false, "Polish Zloty", null, "PLN", null },
                    { new Guid("75464266-69d7-4c9f-8f5d-68f0d04a772c"), "Cash", null, null, false, "Icelandic Krona", null, "ISK", null },
                    { new Guid("763e302d-3954-4792-bfc3-827db5fdbd65"), "Cash", null, null, false, "Algerian Dinar", null, "DZD", null },
                    { new Guid("7821c62c-8206-4a57-85ce-ed93070578f9"), "Cash", null, null, false, "Guinean Franc", null, "GNF", null },
                    { new Guid("7c508994-8a32-4532-a296-31f7d40a07d4"), "Cash", null, null, false, "Brazilian Real", null, "BRL", null },
                    { new Guid("820c0378-6344-4fa6-b8fc-98b07161e413"), "Cash", null, null, false, "Bolivian Boliviano", null, "BOB", null },
                    { new Guid("84eacc01-54ad-40ba-b18d-2467d4181815"), "Cash", null, null, false, "West African CFA Franc", null, "XOF", null },
                    { new Guid("85268ee3-9701-473d-9cee-f5710de42269"), "Cash", null, null, false, "US Dollar", null, "USD", null },
                    { new Guid("8e8041eb-2a40-4b5a-8859-925efcd97410"), "Cash", null, null, false, "Japanese Yen", null, "JPY", null },
                    { new Guid("8eb74adf-024b-4aff-9219-b68fe330a710"), "Cash", null, null, false, "Cuban Peso", null, "CUP", null },
                    { new Guid("90dc230a-8ca3-4080-81f5-460d2805a2a7"), "Cash", null, null, false, "Belize Dollar", null, "BZD", null },
                    { new Guid("913e610b-ee6d-4181-b202-6bf281b9e284"), "Cash", null, null, false, "Chinese Yuan", null, "CNY", null },
                    { new Guid("9156298b-7a49-499b-97ae-1819fd0a489e"), "Cash", null, null, false, "Burundian Franc", null, "BIF", null },
                    { new Guid("92dd6c84-1cb3-40b0-9707-73e5d6063475"), "Cash", null, null, false, "Seychellois Rupee", null, "SCR", null },
                    { new Guid("92de6f4f-2d85-4469-a186-164fea162980"), "Cash", null, null, false, "Tunisian Dinar", null, "TND", null },
                    { new Guid("93386720-dcad-4d59-9025-d3ecf09c71a6"), "Cash", null, null, false, "Maldivian Rufiyaa", null, "MVR", null },
                    { new Guid("942b72ad-972e-4e9d-860c-ef01e244042f"), "Cash", null, null, false, "Argentine Peso", null, "ARS", null },
                    { new Guid("948194e7-e4ed-4c7c-bc7e-249c496d4c59"), "Cash", null, null, false, "Liberian Dollar", null, "LRD", null },
                    { new Guid("953dd944-6505-4f9b-9b47-3b2ca92e80dc"), "Cash", null, null, false, "Israeli New Shekel", null, "ILS", null },
                    { new Guid("964c1f82-cfad-4a7e-84db-b72a67285f21"), "Cash", null, null, false, "Moldovan Leu", null, "MDL", null },
                    { new Guid("9a469ae0-5049-47b7-9b72-f91cdce34d4c"), "Cash", null, null, false, "Paraguayan Guarani", null, "PYG", null },
                    { new Guid("9d0118d2-b19a-47cb-868e-b3e4bc49deb5"), "Cash", null, null, false, "Singapore Dollar", null, "SGD", null },
                    { new Guid("a14c3f63-562b-41b9-8abd-4d88bc69a941"), "Cash", null, null, false, "Zimbabwean Dollar", null, "ZWL", null },
                    { new Guid("a1caaa29-0b72-4e5d-ba0a-5c90ed5aa897"), "Cash", null, null, false, "Honduran Lempira", null, "HNL", null },
                    { new Guid("a2dcbcbe-ff34-48e3-8160-8c7966d70ad7"), "Cash", null, null, false, "São Tomé and Príncipe Dobra", null, "STN", null },
                    { new Guid("a4514e8c-e00b-4d59-aa89-86eebb3d33d3"), "Cash", null, null, false, "Georgian Lari", null, "GEL", null },
                    { new Guid("a586da22-e5a9-4598-9b59-42014b4cd8fa"), "Cash", null, null, false, "South African Rand", null, "ZAR", null },
                    { new Guid("a59f4255-8a85-4eb2-8f4e-881359fc0cf4"), "Cash", null, null, false, "Bangladeshi Taka", null, "BDT", null },
                    { new Guid("a665e754-e608-407e-b47c-94dcf212141f"), "Cash", null, null, false, "Guatemalan Quetzal", null, "GTQ", null },
                    { new Guid("a669b9e9-9a15-4da4-8abf-899264f477e7"), "Cash", null, null, false, "Kenyan Shilling", null, "KES", null },
                    { new Guid("a7371f04-e9d1-4762-940b-9aa680471f90"), "Cash", null, null, false, "Somali Shilling", null, "SOS", null },
                    { new Guid("a7bcaa45-86e1-41ab-8b55-73da45d1ddfa"), "Cash", null, null, false, "Saudi Riyal", null, "SAR", null },
                    { new Guid("a7df8de5-2fbb-4746-b957-cfe155b83ad0"), "Cash", null, null, false, "Euro", null, "EUR", null },
                    { new Guid("a89fea51-7879-4b59-8123-037523474ccf"), "Cash", null, null, false, "Guyanese Dollar", null, "GYD", null },
                    { new Guid("a93bb478-1d6d-4719-af30-a143173c2ec2"), "Cash", null, null, false, "Chilean Peso", null, "CLP", null },
                    { new Guid("aa9801cf-001f-4bbb-8a3f-f9ff0303a2a6"), "Cash", null, null, false, "Iranian Rial", null, "IRR", null },
                    { new Guid("ab47e1e4-88f5-4946-9ee7-51bce572d1b7"), "Cash", null, null, false, "Brunei Dollar", null, "BND", null },
                    { new Guid("addd50a0-ecf3-4abd-ab68-365f342dd20e"), "Cash", null, null, false, "Iraqi Dinar", null, "IQD", null },
                    { new Guid("af3a1dcc-36e4-4a0e-937c-16f10dfd89b4"), "Cash", null, null, false, "Kazakhstani Tenge", null, "KZT", null },
                    { new Guid("b0445410-3edc-4cc7-890b-fb3076047f8d"), "Cash", null, null, false, "Uruguayan Peso", null, "UYU", null },
                    { new Guid("b149f3de-a94f-4120-8dda-fe7083d48c9c"), "Cash", null, null, false, "Central African Republic Franc", null, "CAF", null },
                    { new Guid("b14e6254-c8f2-458b-9f88-01a23e581634"), "Cash", null, null, false, "Egyptian Pound", null, "EGP", null },
                    { new Guid("b1934c1a-9ebf-4a93-a319-32099930191b"), "Cash", null, null, false, "Norwegian Krone", null, "NOK", null },
                    { new Guid("b7528203-349a-464a-a868-4b5abdaa2611"), "Cash", null, null, false, "Malawian Kwacha", null, "MWK", null },
                    { new Guid("b79c2d08-1af4-4768-bcd4-2c2e832acc9d"), "Cash", null, null, false, "Hungarian Forint", null, "HUF", null },
                    { new Guid("ba0e5661-a1e7-4623-809c-094b43dc36e5"), "Cash", null, null, false, "Venezuelan Bolívar Soberano", null, "VES", null },
                    { new Guid("babade4b-64b5-4083-b0ec-a90d6a27886c"), "Cash", null, null, false, "Mongolian Tugrik", null, "MNT", null },
                    { new Guid("bb9e380e-fabf-4fca-82b1-f9df140ca702"), "Cash", null, null, false, "Turkmenistani Manat", null, "TMT", null },
                    { new Guid("bc9a5895-5cd5-4079-9670-92697463b441"), "Cash", null, null, false, "Mauritian Rupee", null, "MUR", null },
                    { new Guid("bd554dc8-122c-4c30-b6ae-e02497bde339"), "Cash", null, null, false, "Romanian Leu", null, "RON", null },
                    { new Guid("c1633cef-f612-42e8-870a-9364413eea5f"), "Cash", null, null, false, "British Pound Sterling", null, "GBP", null },
                    { new Guid("c17debd5-21e9-469d-ab53-03c03693a1c3"), "Cash", null, null, false, "Myanmar Kyat", null, "MMK", null },
                    { new Guid("c5c8eba9-e580-43ec-9b7b-3e8934c54e6e"), "Cash", null, null, false, "Belarusian Ruble", null, "BYN", null },
                    { new Guid("c6a1e175-611b-4ef7-9ce3-5ccdabc272b8"), "Cash", null, null, false, "Philippine Peso", null, "PHP", null },
                    { new Guid("c89647ac-cac1-42eb-831b-3b1143a84c84"), "Cash", null, null, false, "Hong Kong Dollar", null, "HKD", null },
                    { new Guid("c934342b-c38a-4751-bd7d-c0f4368c10c3"), "Cash", null, null, false, "Nigerian Naira", null, "NGN", null },
                    { new Guid("c968759e-0abd-420b-b926-6526e7685312"), "Cash", null, null, false, "Jamaican Dollar", null, "JMD", null },
                    { new Guid("ca7aef06-e664-4012-ad1c-cacc10bdda11"), "Cash", null, null, false, "Uzbekistani Som", null, "UZS", null },
                    { new Guid("cb1c4b81-4e8e-473d-9c8e-b7aa4cb97542"), "Cash", null, null, false, "Vietnamese Dong", null, "VND", null },
                    { new Guid("cbcf9772-59c7-4c89-99a9-2b791ca376c9"), "Cash", null, null, false, "Kyrgyzstani Som", null, "KGS", null },
                    { new Guid("ccda8f84-3dcd-454b-a1db-d2ef253328ff"), "Cash", null, null, false, "Bahamian Dollar", null, "BSD", null },
                    { new Guid("cd52c20b-773b-4187-baa5-dcb1d92746d6"), "Cash", null, null, false, "Bermudian Dollar", null, "BMD", null },
                    { new Guid("cf28b256-9301-4c92-8410-c7335c7c92d8"), "Cash", null, null, false, "Sudanese Pound", null, "SDG", null },
                    { new Guid("d0fb75d6-96f0-4510-8a4f-2ff680e7778c"), "Cash", null, null, false, "Ukrainian Hryvnia", null, "UAH", null },
                    { new Guid("d309920e-3986-43d0-85dd-b9df5080c1a6"), "Cash", null, null, false, "Barbadian Dollar", null, "BBD", null },
                    { new Guid("d43cb3b5-8ace-4b7f-92c9-af9da9d91ee5"), "Cash", null, null, false, "Moroccan Dirham", null, "MAD", null },
                    { new Guid("d865854f-20d5-486f-ac7d-a8e8a42cb753"), "Cash", null, null, false, "Gambian Dalasi", null, "GMD", null },
                    { new Guid("dd9b7f44-84d1-4d7c-aaf1-613266ac23d0"), "Cash", null, null, false, "Qatari Riyal", null, "QAR", null },
                    { new Guid("e02a5a41-80b2-4ca8-8b79-9233fb090af1"), "Cash", null, null, false, "Panamanian Balboa", null, "PAB", null },
                    { new Guid("e5d1db03-4961-4b0a-9981-09205c145ce0"), "Cash", null, null, false, "Czech Koruna", null, "CZK", null },
                    { new Guid("e7966360-4380-41bb-a51e-d3985635e5d2"), "Cash", null, null, false, "Croatian Kuna", null, "HRK", null },
                    { new Guid("eb72b39e-2038-413d-bf6e-cddacfd3a8ac"), "Cash", null, null, false, "Pakistani Rupee", null, "PKR", null },
                    { new Guid("eca9bbd3-5240-4b4c-8575-f3a59c947b24"), "Cash", null, null, false, "Rwandan Franc", null, "RWF", null },
                    { new Guid("ed3d69e7-b4a6-429a-a5e8-0e74538603bf"), "Cash", null, null, false, "Libyan Dinar", null, "LYD", null },
                    { new Guid("f40f635a-327b-4f7c-8468-594190e6c824"), "Cash", null, null, false, "Central African CFA Franc", null, "XAF", null },
                    { new Guid("f7608b63-5379-4a27-9a4a-9cb439f0c6bf"), "Cash", null, null, false, "Colombian Peso", null, "COP", null },
                    { new Guid("f9bc65d5-f368-46fc-8be7-50289a7c6aaf"), "Cash", null, null, false, "Syrian Pound", null, "SYP", null },
                    { new Guid("fc10ef50-49f4-41ed-ab1f-06db14675969"), "Cash", null, null, false, "South Sudanese Pound", null, "SSP", null },
                    { new Guid("fc95bb8e-2778-44bd-a504-867520074984"), "Cash", null, null, false, "Namibian Dollar", null, "NAD", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("011bf9f2-19ac-4e0f-8ab0-7ae450011d39"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("016853d1-a20d-40d9-89b0-8f9223d817dc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("039fe71b-dc81-4410-9491-52dd39481b9c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("04133db8-dac2-49b5-b1c6-e01498e55dab"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("04425aa8-2b84-4068-8afc-fb8d4422bd64"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("051a2dc8-be73-4ca5-8b9c-abf89c330e1d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0757324f-a547-4cfa-8f51-076ec2cd46bf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0ac2b441-37ca-4763-aaec-c42f48e2714d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0be14c9b-c1b5-482e-bd34-88dd1fa04470"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0c0dbd88-5565-45e7-9281-c37fab543c12"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0cc652b9-0848-4056-9f67-b045ae3dd704"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("0ed1b0fc-27a3-4af7-b220-b02423122854"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("100b0b5d-f9f9-427e-b6ce-9490f751ed00"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("104cf31a-7608-4183-b336-448851de2c20"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("14f8a913-391c-4eb9-8b3f-d9ff79419922"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("163675aa-8a0d-4edd-9299-3ecfb18863b3"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("18ac3af6-a364-423c-88ed-5c97e9ebaa47"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("190481d0-49c4-4874-b708-87050e968608"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1ad046d8-6229-45a7-8eab-b5f726c5c588"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1bec1473-f447-4e6b-ba7d-c1900863efa5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("1e39ab48-e189-43f9-b33c-057bdadb5213"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("20531207-647d-418a-b73c-70cff4b02863"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("20f5ffa3-082a-467e-bdf9-e03e23b1d7f7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("29ce6769-6bf9-4922-ac58-3ad21cc0a3c4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("2a092769-62f9-4dca-86a2-59d3d2953d4d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("322ac18b-bf6f-40fe-9190-139b7d4de83a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("33638d97-d492-4d21-8090-0f17fcf7618b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("34563c3f-a91e-49b4-b3af-37a58c93f452"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3553faec-0c2a-441b-a01e-8ce54e6042d0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("35aba6c3-b9bc-4198-a8ea-9b77a04797da"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("35d63400-d1cd-4c00-adc9-0d64d396e534"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3696a040-2efa-4b33-9975-cf1d24c5aa16"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3a0b2c69-5c37-4fc4-b104-45dcd7c1bb0b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3d43f193-d370-43ed-9d53-1199214c8e43"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3f2b3bc5-2f85-4593-abef-56038358305e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4052ae6c-da65-435b-b808-f5edef965c50"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("40571b4f-291f-408f-b93b-3ecdc2e72ea3"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("40e5a52b-01bd-4264-a05c-9b3e59f2e989"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("42e6af7f-774d-46c7-a17b-54d2e9ea844c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("43fb8d35-e60a-4249-b330-f58f6589bf49"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("45af5a4b-d11c-4758-b7d9-523d37281773"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("46b04247-7109-4cf4-8f84-521bd3e0e08c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4a0e927d-8a55-43a2-a2ca-bfcab9e2c5a8"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4ad2f770-cd8a-44ab-8f9f-4a3d1efd5586"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4d1f12b3-df31-40b4-84f2-1784956a3af9"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4e31bb57-33ca-47ce-a114-0709cb8563b5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4ed3d4c2-9b5c-4a91-83a2-2bc6dde2b5c5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("4f9df6ee-dccd-456d-885c-cbdb55af9dcc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5127a26d-c355-4530-9ecd-a89b67fd4522"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("54e59f4e-649d-46fe-8904-0f18ce017c4a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("560bca24-a063-43c3-ac53-473633820ce6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5714346e-efde-4eea-9b9d-14c0267b75ce"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("5bee2db3-1b18-4694-b5f0-459a87a6097c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("60a959de-eab6-49db-90ed-10ec0970f944"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("61c59eb4-6e91-4057-9b87-dc8d3d6def2a"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("628de140-d182-4621-8d31-cb467d2003e5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("63febbff-3242-4874-9c65-ccba0a1d873d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("65bb4191-52ff-4c1d-ad87-b79e1ce2eca7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("664e5334-e253-4c43-96d7-0785ccd56960"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("66f539b7-551c-44e3-bc0f-18d5bcbd3f4d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6b35e375-0bf3-4388-a24a-953e82b9a296"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6b6d7b91-5dc2-4c5d-9a53-0f3e0f869b94"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6c54ee8c-6af1-4e1f-bfeb-7898cd39de99"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6e47ac3b-258e-4326-9fe7-632ccd04fa32"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("702af8bc-81c5-4982-89f5-20eb73c996c2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("705ed296-9f28-4e1a-b28d-49921524bd16"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("73fabb4b-df49-4697-8f78-a275480c95cc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("74fd7619-1182-4cc1-a016-56e1d9ab9974"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("75464266-69d7-4c9f-8f5d-68f0d04a772c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("763e302d-3954-4792-bfc3-827db5fdbd65"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7821c62c-8206-4a57-85ce-ed93070578f9"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7c508994-8a32-4532-a296-31f7d40a07d4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("820c0378-6344-4fa6-b8fc-98b07161e413"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("84eacc01-54ad-40ba-b18d-2467d4181815"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("85268ee3-9701-473d-9cee-f5710de42269"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("8e8041eb-2a40-4b5a-8859-925efcd97410"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("8eb74adf-024b-4aff-9219-b68fe330a710"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("90dc230a-8ca3-4080-81f5-460d2805a2a7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("913e610b-ee6d-4181-b202-6bf281b9e284"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9156298b-7a49-499b-97ae-1819fd0a489e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("92dd6c84-1cb3-40b0-9707-73e5d6063475"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("92de6f4f-2d85-4469-a186-164fea162980"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("93386720-dcad-4d59-9025-d3ecf09c71a6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("942b72ad-972e-4e9d-860c-ef01e244042f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("948194e7-e4ed-4c7c-bc7e-249c496d4c59"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("953dd944-6505-4f9b-9b47-3b2ca92e80dc"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("964c1f82-cfad-4a7e-84db-b72a67285f21"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9a469ae0-5049-47b7-9b72-f91cdce34d4c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9d0118d2-b19a-47cb-868e-b3e4bc49deb5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a14c3f63-562b-41b9-8abd-4d88bc69a941"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a1caaa29-0b72-4e5d-ba0a-5c90ed5aa897"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a2dcbcbe-ff34-48e3-8160-8c7966d70ad7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a4514e8c-e00b-4d59-aa89-86eebb3d33d3"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a586da22-e5a9-4598-9b59-42014b4cd8fa"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a59f4255-8a85-4eb2-8f4e-881359fc0cf4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a665e754-e608-407e-b47c-94dcf212141f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a669b9e9-9a15-4da4-8abf-899264f477e7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a7371f04-e9d1-4762-940b-9aa680471f90"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a7bcaa45-86e1-41ab-8b55-73da45d1ddfa"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a7df8de5-2fbb-4746-b957-cfe155b83ad0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a89fea51-7879-4b59-8123-037523474ccf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("a93bb478-1d6d-4719-af30-a143173c2ec2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("aa9801cf-001f-4bbb-8a3f-f9ff0303a2a6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ab47e1e4-88f5-4946-9ee7-51bce572d1b7"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("addd50a0-ecf3-4abd-ab68-365f342dd20e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("af3a1dcc-36e4-4a0e-937c-16f10dfd89b4"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b0445410-3edc-4cc7-890b-fb3076047f8d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b149f3de-a94f-4120-8dda-fe7083d48c9c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b14e6254-c8f2-458b-9f88-01a23e581634"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b1934c1a-9ebf-4a93-a319-32099930191b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b7528203-349a-464a-a868-4b5abdaa2611"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b79c2d08-1af4-4768-bcd4-2c2e832acc9d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ba0e5661-a1e7-4623-809c-094b43dc36e5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("babade4b-64b5-4083-b0ec-a90d6a27886c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("bb9e380e-fabf-4fca-82b1-f9df140ca702"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("bc9a5895-5cd5-4079-9670-92697463b441"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("bd554dc8-122c-4c30-b6ae-e02497bde339"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c1633cef-f612-42e8-870a-9364413eea5f"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c17debd5-21e9-469d-ab53-03c03693a1c3"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c5c8eba9-e580-43ec-9b7b-3e8934c54e6e"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c6a1e175-611b-4ef7-9ce3-5ccdabc272b8"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c89647ac-cac1-42eb-831b-3b1143a84c84"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c934342b-c38a-4751-bd7d-c0f4368c10c3"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c968759e-0abd-420b-b926-6526e7685312"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ca7aef06-e664-4012-ad1c-cacc10bdda11"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("cb1c4b81-4e8e-473d-9c8e-b7aa4cb97542"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("cbcf9772-59c7-4c89-99a9-2b791ca376c9"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ccda8f84-3dcd-454b-a1db-d2ef253328ff"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("cd52c20b-773b-4187-baa5-dcb1d92746d6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("cf28b256-9301-4c92-8410-c7335c7c92d8"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d0fb75d6-96f0-4510-8a4f-2ff680e7778c"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d309920e-3986-43d0-85dd-b9df5080c1a6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d43cb3b5-8ace-4b7f-92c9-af9da9d91ee5"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d865854f-20d5-486f-ac7d-a8e8a42cb753"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("dd9b7f44-84d1-4d7c-aaf1-613266ac23d0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e02a5a41-80b2-4ca8-8b79-9233fb090af1"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e5d1db03-4961-4b0a-9981-09205c145ce0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("e7966360-4380-41bb-a51e-d3985635e5d2"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("eb72b39e-2038-413d-bf6e-cddacfd3a8ac"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("eca9bbd3-5240-4b4c-8575-f3a59c947b24"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("ed3d69e7-b4a6-429a-a5e8-0e74538603bf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f40f635a-327b-4f7c-8468-594190e6c824"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f7608b63-5379-4a27-9a4a-9cb439f0c6bf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f9bc65d5-f368-46fc-8be7-50289a7c6aaf"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("fc10ef50-49f4-41ed-ab1f-06db14675969"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("fc95bb8e-2778-44bd-a504-867520074984"));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "TransactionLegs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Source",
                table: "Operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "AssetClass",
                table: "Assets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetClass", "CountryCode", "Industry", "IsCustom", "Name", "Sector", "Ticker", "UserId" },
                values: new object[,]
                {
                    { new Guid("024f8c86-6909-48cd-8d73-c3e459d3179d"), 4, null, null, false, "Eritrean Nakfa", null, "ERN", null },
                    { new Guid("026f86b5-3c88-4169-99d4-95850879e87a"), 4, null, null, false, "Romanian Leu", null, "RON", null },
                    { new Guid("03a49e55-04e6-48bc-9a7c-a8f41962815c"), 4, null, null, false, "Kenyan Shilling", null, "KES", null },
                    { new Guid("03c82b37-b491-4eda-94f9-cd674fdc9e4c"), 4, null, null, false, "Central African Republic Franc", null, "CAF", null },
                    { new Guid("05e06868-8f76-4793-95e8-2c712cc0894a"), 4, null, null, false, "Japanese Yen", null, "JPY", null },
                    { new Guid("07f88392-d02d-4879-9cf0-38bf7ee153f1"), 4, null, null, false, "Afghan Afghani", null, "AFN", null },
                    { new Guid("0d8f3b42-976d-486b-bf2a-caa7b361174d"), 4, null, null, false, "Macanese Pataca", null, "MOP", null },
                    { new Guid("0dfdf499-d77d-414f-b124-a9f61cc43302"), 4, null, null, false, "West African CFA Franc", null, "XOF", null },
                    { new Guid("0e3a43c3-ced3-44c9-8eff-92125f69f84e"), 4, null, null, false, "Hong Kong Dollar", null, "HKD", null },
                    { new Guid("108eb812-5056-47f4-bd4d-3e8795488ccd"), 4, null, null, false, "Singapore Dollar", null, "SGD", null },
                    { new Guid("12061183-c46c-4264-a26d-6089ed262931"), 4, null, null, false, "Iraqi Dinar", null, "IQD", null },
                    { new Guid("1270444d-4246-489e-89af-cae50d2413b9"), 4, null, null, false, "Namibian Dollar", null, "NAD", null },
                    { new Guid("12836d29-5bd7-44be-9899-ea5b62deafda"), 4, null, null, false, "Panamanian Balboa", null, "PAB", null },
                    { new Guid("12a45ab9-0166-4195-94cb-d61ae5c646bc"), 4, null, null, false, "Maldivian Rufiyaa", null, "MVR", null },
                    { new Guid("14ecd1a3-fc23-459b-95fa-d96f256514f6"), 4, null, null, false, "Comorian Franc", null, "KMF", null },
                    { new Guid("184cfbd0-36c3-4796-b42f-51372a39fcab"), 4, null, null, false, "Bangladeshi Taka", null, "BDT", null },
                    { new Guid("18bf8d2c-8c92-473e-a8fe-7db0691e2753"), 4, null, null, false, "Brunei Dollar", null, "BND", null },
                    { new Guid("199154c4-eb9e-4916-bd4c-f69025e1ad5e"), 4, null, null, false, "Paraguayan Guarani", null, "PYG", null },
                    { new Guid("1997c794-2098-483c-87bf-c0b6272cc1de"), 4, null, null, false, "Iranian Rial", null, "IRR", null },
                    { new Guid("1ca7f042-fa02-4c69-8609-59ab3de4e87d"), 4, null, null, false, "Rwandan Franc", null, "RWF", null },
                    { new Guid("1dd71a42-4b2e-4b4c-b6ba-328c6d724473"), 4, null, null, false, "Armenian Dram", null, "AMD", null },
                    { new Guid("20a4575e-5819-4fad-ae8a-d91eaa9a005f"), 4, null, null, false, "Turkmenistani Manat", null, "TMT", null },
                    { new Guid("2193cc16-f96b-414e-8bf9-d52899fd199e"), 4, null, null, false, "Kuwaiti Dinar", null, "KWD", null },
                    { new Guid("21e1ce6e-c52c-490c-9714-e45b156a1540"), 4, null, null, false, "Honduran Lempira", null, "HNL", null },
                    { new Guid("2227b150-7379-4554-9e06-8b0a00829ec0"), 4, null, null, false, "Sri Lankan Rupee", null, "LKR", null },
                    { new Guid("24a133df-c52c-48b9-ae6b-f912c3217c78"), 4, null, null, false, "Swiss Franc", null, "CHF", null },
                    { new Guid("25676d7f-2101-4485-bbd9-e9aa10fc13e5"), 4, null, null, false, "Mauritian Rupee", null, "MUR", null },
                    { new Guid("2658e8c3-77a2-4462-b3a8-4527dd2ffc67"), 4, null, null, false, "Bulgarian Lev", null, "BGN", null },
                    { new Guid("282e94e2-ecea-4af5-8ca8-b4aa510a9eb0"), 4, null, null, false, "Yemeni Rial", null, "YER", null },
                    { new Guid("29201e8d-21f4-4757-8e3e-769734f488f2"), 4, null, null, false, "Guyanese Dollar", null, "GYD", null },
                    { new Guid("2bb8b9a0-9c95-478e-9fc7-77ca07bf67a1"), 4, null, null, false, "East Caribbean Dollar", null, "XCD", null },
                    { new Guid("2d87129c-96fc-45bb-bfd6-a713ab996c23"), 4, null, null, false, "Russian Ruble", null, "RUB", null },
                    { new Guid("2fa50609-3d49-415a-8165-cfb41dcdd5bc"), 4, null, null, false, "Norwegian Krone", null, "NOK", null },
                    { new Guid("2fdaea83-9f93-4e42-95d9-8a4a284541de"), 4, null, null, false, "Bhutanese Ngultrum", null, "BTN", null },
                    { new Guid("32b49394-032e-4039-b3fb-ec74e90e651e"), 4, null, null, false, "Mozambican Metical", null, "MZN", null },
                    { new Guid("330d6d95-bd76-4261-b45c-757be4c171d0"), 4, null, null, false, "Zambian Kwacha", null, "ZMW", null },
                    { new Guid("334847cd-724e-4658-8651-ad317a79f032"), 4, null, null, false, "Ghanaian Cedi", null, "GHS", null },
                    { new Guid("33d43655-d8a7-494e-b45c-1a8c86b74cc4"), 4, null, null, false, "Sierra Leonean Leone", null, "SLE", null },
                    { new Guid("342ab7b7-b682-4341-94c1-c98dd7a76aa4"), 4, null, null, false, "South Sudanese Pound", null, "SSP", null },
                    { new Guid("34ada21d-ac91-428b-a22b-a45b304132fa"), 4, null, null, false, "Ugandan Shilling", null, "UGX", null },
                    { new Guid("34c46ac5-fb63-4173-9959-ebd39118890f"), 4, null, null, false, "Turkish Lira", null, "TRY", null },
                    { new Guid("39d35c6e-ad87-4b94-8d2f-ad603f1fbd8d"), 4, null, null, false, "Ukrainian Hryvnia", null, "UAH", null },
                    { new Guid("3b136058-452b-4964-abac-045bb7c9be42"), 4, null, null, false, "Thai Baht", null, "THB", null },
                    { new Guid("3f14e688-cf72-43d2-b4f5-7e264a3059f7"), 4, null, null, false, "Lebanese Pound", null, "LBP", null },
                    { new Guid("455b6463-ae97-4c8e-b76e-0e7fe6695be7"), 4, null, null, false, "Hungarian Forint", null, "HUF", null },
                    { new Guid("457838d7-4434-46c8-a407-8e2f1f7e844f"), 4, null, null, false, "Trinidad and Tobago Dollar", null, "TTD", null },
                    { new Guid("49f1ec15-aab3-4b87-af58-ae2867b05582"), 4, null, null, false, "Colombian Peso", null, "COP", null },
                    { new Guid("4a8d05ff-e55f-4f4b-83ff-bd1eb087e155"), 4, null, null, false, "Dominican Peso", null, "DOP", null },
                    { new Guid("4c99428e-15d2-4a26-814e-df0485fe2ba6"), 4, null, null, false, "Tajikistani Somoni", null, "TJS", null },
                    { new Guid("4cee1848-ce24-4a1e-b984-b8e272059386"), 4, null, null, false, "Canadian Dollar", null, "CAD", null },
                    { new Guid("4eb6fd4a-5770-4d16-b4f1-dec85ded9455"), 4, null, null, false, "Algerian Dinar", null, "DZD", null },
                    { new Guid("51407e6b-b022-4743-a29a-6720956fa82e"), 4, null, null, false, "CFP Franc", null, "XPF", null },
                    { new Guid("53346a1b-ff62-42ba-948c-45f2a7f44bee"), 4, null, null, false, "Bermudian Dollar", null, "BMD", null },
                    { new Guid("53c24d9c-86a2-408c-aa49-ae078e9ab5fc"), 4, null, null, false, "Tunisian Dinar", null, "TND", null },
                    { new Guid("55dc8d16-d3dd-4d64-86c0-ac1cee1d5fd9"), 4, null, null, false, "Serbian Dinar", null, "RSD", null },
                    { new Guid("57e36279-d09f-4d46-8d51-aab67f5a8310"), 4, null, null, false, "Saudi Riyal", null, "SAR", null },
                    { new Guid("595ea6bb-b268-492f-a17d-2529f7480cca"), 4, null, null, false, "Haitian Gourde", null, "HTG", null },
                    { new Guid("5a1f0ab5-2b7c-4ef4-a202-dab1c23036f0"), 4, null, null, false, "Congolese Franc", null, "CDF", null },
                    { new Guid("5d3ef524-0b65-4f94-bd5c-96a7752e44bf"), 4, null, null, false, "Belize Dollar", null, "BZD", null },
                    { new Guid("5dbbbf94-0e92-4590-93c5-4505863ca5f2"), 4, null, null, false, "Angolan Kwanza", null, "AOA", null },
                    { new Guid("5ff97503-b02f-4270-8969-a9dea0e0ccaf"), 4, null, null, false, "Moldovan Leu", null, "MDL", null },
                    { new Guid("6194b501-6c22-4f3f-ba76-1a8f5d1b7229"), 4, null, null, false, "Central African CFA Franc", null, "XAF", null },
                    { new Guid("61de6cb4-9b1a-45fd-a9bd-47a56617e718"), 4, null, null, false, "Euro", null, "EUR", null },
                    { new Guid("64143c05-c227-46bf-b4e9-b50e23dac42a"), 4, null, null, false, "Lao Kip", null, "LAK", null },
                    { new Guid("6469b582-f146-4e4e-8a70-0abe613ee07d"), 4, null, null, false, "Costa Rican Colón", null, "CRC", null },
                    { new Guid("647912a6-4d43-46c7-9b53-9888c005f4b6"), 4, null, null, false, "Czech Koruna", null, "CZK", null },
                    { new Guid("663aed05-3efa-4e23-9add-acae97edfde7"), 4, null, null, false, "Chinese Yuan", null, "CNY", null },
                    { new Guid("66c146e3-808d-4e5d-80aa-c44018cb50eb"), 4, null, null, false, "South Korean Won", null, "KRW", null },
                    { new Guid("691b6fe9-d770-4df5-96f0-1c1ff4096467"), 4, null, null, false, "Malawian Kwacha", null, "MWK", null },
                    { new Guid("6a01b72f-8bdd-43a7-bdec-43165a8338f0"), 4, null, null, false, "Guatemalan Quetzal", null, "GTQ", null },
                    { new Guid("6a2d7d2a-8ee5-4682-aefe-f81089b81264"), 4, null, null, false, "Kyrgyzstani Som", null, "KGS", null },
                    { new Guid("6b6321de-7fae-4a0f-97e6-30f4c29c969e"), 4, null, null, false, "Uruguayan Peso", null, "UYU", null },
                    { new Guid("6c570f89-6b79-442b-87ce-6f08d38faae8"), 4, null, null, false, "Seychellois Rupee", null, "SCR", null },
                    { new Guid("6e63c4ec-68df-44b9-bd5e-24c150470923"), 4, null, null, false, "Chilean Peso", null, "CLP", null },
                    { new Guid("71e7733a-9349-4c4f-91cd-dd8ac062b989"), 4, null, null, false, "Taiwan Dollar", null, "TWD", null },
                    { new Guid("7a21fb6d-2d54-41e8-a71c-59d82a49b807"), 4, null, null, false, "Barbadian Dollar", null, "BBD", null },
                    { new Guid("7b171f95-97f2-4312-9a7b-3af40df2b0ad"), 4, null, null, false, "Croatian Kuna", null, "HRK", null },
                    { new Guid("7be1726b-498d-4445-ac9f-a45fb2cac47e"), 4, null, null, false, "British Pound Sterling", null, "GBP", null },
                    { new Guid("7d5fbafc-964d-4088-be3a-45bc28161d06"), 4, null, null, false, "Albanian Lek", null, "ALL", null },
                    { new Guid("7dbd0cf4-88b5-4d63-9ace-c40b5457e17f"), 4, null, null, false, "Danish Krone", null, "DKK", null },
                    { new Guid("7e29f768-a561-43f2-b142-31096247c127"), 4, null, null, false, "Libyan Dinar", null, "LYD", null },
                    { new Guid("8039eeac-40fa-47cf-bb6b-3b80a8aaed1d"), 4, null, null, false, "Guinean Franc", null, "GNF", null },
                    { new Guid("814337ea-257e-4eff-9b70-77c6241c968e"), 4, null, null, false, "Qatari Riyal", null, "QAR", null },
                    { new Guid("82947a9e-85bd-4c13-a609-080ed08c29f6"), 4, null, null, false, "Vietnamese Dong", null, "VND", null },
                    { new Guid("85458e9d-d3fb-4324-8d5f-37ea3b35de79"), 4, null, null, false, "Sudanese Pound", null, "SDG", null },
                    { new Guid("85d3c698-3004-4698-b8d8-0791d8ffe16a"), 4, null, null, false, "Cuban Peso", null, "CUP", null },
                    { new Guid("8a05b642-daf9-491f-9069-57b0950d0255"), 4, null, null, false, "Mexican Peso", null, "MXN", null },
                    { new Guid("8f4a80c3-c44b-464c-abc2-a6b59acbd735"), 4, null, null, false, "Nicaraguan Córdoba", null, "NIO", null },
                    { new Guid("8fe8d78c-1659-4a13-a5e7-8e609d85e871"), 4, null, null, false, "Australian Dollar", null, "AUD", null },
                    { new Guid("91afd8a5-2ebe-43bc-b2d0-f7305ece6942"), 4, null, null, false, "Gambian Dalasi", null, "GMD", null },
                    { new Guid("946aea29-e85a-4405-8aff-326df580abdb"), 4, null, null, false, "Cayman Islands Dollar", null, "KYD", null },
                    { new Guid("94e17a33-d71c-4b35-89bb-db2f5942d7c1"), 4, null, null, false, "Bosnia and Herzegovina Convertible Mark", null, "BAM", null },
                    { new Guid("9c443b6d-a3e9-4a14-97e8-9844d907625a"), 4, null, null, false, "Uzbekistani Som", null, "UZS", null },
                    { new Guid("9d7b7e3e-865c-41c7-8e89-f293931064b1"), 4, null, null, false, "Azerbaijani Manat", null, "AZN", null },
                    { new Guid("9dff6f64-147f-4d30-a16f-c8fd6e17c0e2"), 4, null, null, false, "Botswana Pula", null, "BWP", null },
                    { new Guid("9e962372-1faf-4058-a26d-b2650cb9f1ae"), 4, null, null, false, "Malaysian Ringgit", null, "MYR", null },
                    { new Guid("9f99abf3-a0f1-438e-8bd4-6f4fe2e4b348"), 4, null, null, false, "Netherlands Antillean Guilder", null, "ANG", null },
                    { new Guid("9fb13e5a-df0b-40f5-b04f-c9007314131c"), 4, null, null, false, "Malagasy Ariary", null, "MGA", null },
                    { new Guid("9fd52c0c-91e2-478b-9d2c-49bed0142057"), 4, null, null, false, "Argentine Peso", null, "ARS", null },
                    { new Guid("a18aa9b9-42ed-4a33-9c6c-905b8c41f3e6"), 4, null, null, false, "Nepalese Rupee", null, "NPR", null },
                    { new Guid("a1f73f99-f262-413b-91c7-2b9434269fe7"), 4, null, null, false, "Swedish Krona", null, "SEK", null },
                    { new Guid("a5647e0e-4afe-4ab0-ba46-14a5946c4d43"), 4, null, null, false, "Indonesian Rupiah", null, "IDR", null },
                    { new Guid("a788cbec-91b6-4926-9ce4-23829fb93c22"), 4, null, null, false, "Syrian Pound", null, "SYP", null },
                    { new Guid("a930e6eb-2e00-4f07-b81d-e3cc93294bb5"), 4, null, null, false, "Somali Shilling", null, "SOS", null },
                    { new Guid("accb3d3f-9427-4f5b-ad55-75cbe5377186"), 4, null, null, false, "Nigerian Naira", null, "NGN", null },
                    { new Guid("b0383f66-0007-496a-9d56-a668121a1310"), 4, null, null, false, "Liberian Dollar", null, "LRD", null },
                    { new Guid("b07afbf6-d542-45fb-9426-04fa7ec8b051"), 4, null, null, false, "Cambodian Riel", null, "KHR", null },
                    { new Guid("b1a794ce-ad5f-4d7f-91a2-819b1dd5e756"), 4, null, null, false, "North Korean Won", null, "KPW", null },
                    { new Guid("b6c97579-8d54-4883-9d8c-5060443ec822"), 4, null, null, false, "Belarusian Ruble", null, "BYN", null },
                    { new Guid("b7eb2fab-df0f-4d01-a59e-04375257610c"), 4, null, null, false, "Myanmar Kyat", null, "MMK", null },
                    { new Guid("b906a6c3-d805-428c-9f7e-9044a0c264b0"), 4, null, null, false, "Egyptian Pound", null, "EGP", null },
                    { new Guid("bc6b3a64-1729-4755-bf55-f912269c9a6f"), 4, null, null, false, "Djiboutian Franc", null, "DJF", null },
                    { new Guid("be8b0477-748b-454b-9dee-4a03af13b079"), 4, null, null, false, "Jamaican Dollar", null, "JMD", null },
                    { new Guid("c1142a11-84bf-4be5-b83c-2b3ee6e405d5"), 4, null, null, false, "Israeli New Shekel", null, "ILS", null },
                    { new Guid("c15412f6-7dec-43c8-ae41-79e83a9b118c"), 4, null, null, false, "Indian Rupee", null, "INR", null },
                    { new Guid("c22d2e2e-bf37-4cac-9b1c-f5571a559d97"), 4, null, null, false, "Mongolian Tugrik", null, "MNT", null },
                    { new Guid("c2447cad-09cd-4d88-8ee6-fad1bf6439db"), 4, null, null, false, "US Dollar", null, "USD", null },
                    { new Guid("c4140e31-efb7-49a2-94b4-9bcb999c2d7b"), 4, null, null, false, "Cape Verdean Escudo", null, "CVE", null },
                    { new Guid("c7e16a4e-bf28-4e1d-9b26-b59ae6ba596b"), 4, null, null, false, "Bolivian Boliviano", null, "BOB", null },
                    { new Guid("c85bb462-c65b-4ebf-b348-f862f3cb4582"), 4, null, null, false, "Aruban Florin", null, "AWG", null },
                    { new Guid("c88119b8-fa8f-4232-b970-377e155104a5"), 4, null, null, false, "UAE Dirham", null, "AED", null },
                    { new Guid("c88e8959-76e6-4bc6-a4ae-1cc4a49b2711"), 4, null, null, false, "Surinamese Dollar", null, "SRD", null },
                    { new Guid("c89e26f6-1910-4734-a225-b179f950b42f"), 4, null, null, false, "Lesotho Loti", null, "LSL", null },
                    { new Guid("c92098b2-ba07-4aff-8b7b-52a5c0518c3b"), 4, null, null, false, "South African Rand", null, "ZAR", null },
                    { new Guid("c9df998b-365a-45e1-a54d-cab06e00ce1f"), 4, null, null, false, "Icelandic Krona", null, "ISK", null },
                    { new Guid("ca036578-a1a9-4449-8c11-3f0735f1ce96"), 4, null, null, false, "Brazilian Real", null, "BRL", null },
                    { new Guid("cf37decf-2f5f-4f86-8a88-ee20a2b41150"), 4, null, null, false, "Ethiopian Birr", null, "ETB", null },
                    { new Guid("d0c9b454-2b6d-43bd-b1fb-1b23faeddc6f"), 4, null, null, false, "Georgian Lari", null, "GEL", null },
                    { new Guid("d1c48450-ed21-4672-8ebf-e67b27baf038"), 4, null, null, false, "Philippine Peso", null, "PHP", null },
                    { new Guid("d1d9219b-d1e8-42e4-a9a4-3b1e6885890d"), 4, null, null, false, "Venezuelan Bolívar Soberano", null, "VES", null },
                    { new Guid("d1e9bb46-2643-4818-b47d-391cef92ffed"), 4, null, null, false, "Polish Zloty", null, "PLN", null },
                    { new Guid("d3cb4a85-0a91-4981-b460-9cd0b303821a"), 4, null, null, false, "Peruvian Sol", null, "PEN", null },
                    { new Guid("d3d7342b-a4aa-4832-b082-bb95f1b3c9c1"), 4, null, null, false, "São Tomé and Príncipe Dobra", null, "STN", null },
                    { new Guid("d5a778db-61e5-4fc0-864c-0f3b45985afa"), 4, null, null, false, "Pakistani Rupee", null, "PKR", null },
                    { new Guid("d5e3b831-e600-4a7e-95eb-cbc87199a32b"), 4, null, null, false, "Macedonian Denar", null, "MKD", null },
                    { new Guid("dcdd88a5-afc6-48da-9c18-3fe19a16b3a0"), 4, null, null, false, "Zimbabwean Dollar", null, "ZWL", null },
                    { new Guid("ddc37a97-9fe6-45dd-99be-601a9d59daa2"), 4, null, null, false, "Burundian Franc", null, "BIF", null },
                    { new Guid("e4799e8d-87d5-4139-9686-5549c64be7b8"), 4, null, null, false, "Moroccan Dirham", null, "MAD", null },
                    { new Guid("e4c5709d-1598-4aa5-997b-557934e63b7a"), 4, null, null, false, "Falkland Islands Pound", null, "FKP", null },
                    { new Guid("e4d2065d-9c41-4132-bf08-e992caa58ec4"), 4, null, null, false, "Kazakhstani Tenge", null, "KZT", null },
                    { new Guid("e74a4a65-f4fb-45b4-a5e2-065eacd13961"), 4, null, null, false, "Swazi Lilangeni", null, "SZL", null },
                    { new Guid("e7a9a8f3-0bdb-45ba-a858-34b3bf79d305"), 4, null, null, false, "Bahamian Dollar", null, "BSD", null },
                    { new Guid("e9456e82-e049-4be6-8747-a68bc46382d0"), 4, null, null, false, "Omani Rial", null, "OMR", null },
                    { new Guid("f1fadfbe-51d5-49fb-85e0-504ae550bdd0"), 4, null, null, false, "Tanzanian Shilling", null, "TZS", null },
                    { new Guid("f5e8f9b7-a142-4892-a71f-d8e3f8646d5f"), 4, null, null, false, "Jordanian Dinar", null, "JOD", null },
                    { new Guid("f7219f13-1120-4c81-b058-2ac8b09eb06a"), 4, null, null, false, "Bahraini Dinar", null, "BHD", null }
                });
        }
    }
}
