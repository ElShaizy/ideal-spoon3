<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="focusControl" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<q-container
			fluid
			data-key="F_PROPERTY"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible">
						<q-group-box-container
							v-if="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible"
							id="F_PROPERTY__PSEUD__NEWGRP01"
							v-bind="controls.F_PROPERTY__PSEUD__NEWGRP01"
							:is-visible="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible">
							<!-- Start F_PROPERTY__PSEUD__NEWGRP01 -->
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.isVisible"
										class="q-image"
										v-bind="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO"
										v-on="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.props"
											v-on="controls.F_PROPERTY__PROPERTIES__MAIN_PHOTO.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__SOLD.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__SOLD.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__SOLD.isVisible"
										class="i-checkbox"
										v-bind="controls.F_PROPERTY__PROPERTIES__SOLD"
										v-on="controls.F_PROPERTY__PROPERTIES__SOLD.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__SOLD.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<template #label>
											<q-checkbox
												v-if="controls.F_PROPERTY__PROPERTIES__SOLD.isVisible"
												v-bind="controls.F_PROPERTY__PROPERTIES__SOLD.props"
												v-on="controls.F_PROPERTY__PROPERTIES__SOLD.handlers" />
										</template>
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__TITLE.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__TITLE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__TITLE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__TITLE"
										v-on="controls.F_PROPERTY__PROPERTIES__TITLE.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__TITLE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PROPERTY__PROPERTIES__TITLE.props"
											@blur="onBlur(controls.F_PROPERTY__PROPERTIES__TITLE, model.ValTitle.value)"
											@change="model.ValTitle.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__PRICE.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__PRICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__PRICE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__PRICE"
										v-on="controls.F_PROPERTY__PROPERTIES__PRICE.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__PRICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PROPERTY__PROPERTIES__PRICE.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__PRICE.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.isVisible"
										class="i-textarea"
										v-bind="controls.F_PROPERTY__PROPERTIES__DESCRIPTION"
										v-on="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.props"
											v-on="controls.F_PROPERTY__PROPERTIES__DESCRIPTION.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End F_PROPERTY__PSEUD__NEWGRP01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible">
						<q-group-collapsible
							v-if="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible"
							id="F_PROPERTY__PSEUD__NEWGRP02"
							v-bind="controls.F_PROPERTY__PSEUD__NEWGRP02"
							v-on="controls.F_PROPERTY__PSEUD__NEWGRP02.handlers">
							<!-- Start F_PROPERTY__PSEUD__NEWGRP02 -->
							<q-row v-if="controls.F_PROPERTY__CITY__CITY.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__CITY__CITY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__CITY__CITY.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__CITY__CITY"
										v-on="controls.F_PROPERTY__CITY__CITY.handlers"
										:loading="controls.F_PROPERTY__CITY__CITY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.F_PROPERTY__CITY__CITY.isVisible"
											v-bind="controls.F_PROPERTY__CITY__CITY.props"
											v-on="controls.F_PROPERTY__CITY__CITY.handlers" />
										<q-see-more-f-property-city-city
											v-if="controls.F_PROPERTY__CITY__CITY.seeMoreIsVisible"
											v-bind="controls.F_PROPERTY__CITY__CITY.seeMoreParams"
											v-on="controls.F_PROPERTY__CITY__CITY.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__COUNTRY__COUNTRY.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__COUNTRY__COUNTRY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__COUNTRY__COUNTRY.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__COUNTRY__COUNTRY"
										v-on="controls.F_PROPERTY__COUNTRY__COUNTRY.handlers"
										:loading="controls.F_PROPERTY__COUNTRY__COUNTRY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PROPERTY__COUNTRY__COUNTRY.props"
											@blur="onBlur(controls.F_PROPERTY__COUNTRY__COUNTRY, model.CityCountryValCountry.value)"
											@change="model.CityCountryValCountry.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End F_PROPERTY__PSEUD__NEWGRP02 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__NEWGRP03.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__NEWGRP03.isVisible">
						<q-group-collapsible
							v-if="controls.F_PROPERTY__PSEUD__NEWGRP03.isVisible"
							id="F_PROPERTY__PSEUD__NEWGRP03"
							v-bind="controls.F_PROPERTY__PSEUD__NEWGRP03"
							v-on="controls.F_PROPERTY__PSEUD__NEWGRP03.handlers">
							<!-- Start F_PROPERTY__PSEUD__NEWGRP03 -->
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.isVisible || controls.F_PROPERTY__PROPERTIES__SIZEM2.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER"
										v-on="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__BATHROOMSNUMBER.props"
											@update:model-value="model.ValBathroomsnumber.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__SIZEM2.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__SIZEM2.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__SIZEM2"
										v-on="controls.F_PROPERTY__PROPERTIES__SIZEM2.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__SIZEM2.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PROPERTY__PROPERTIES__SIZEM2.props"
											@blur="onBlur(controls.F_PROPERTY__PROPERTIES__SIZEM2, model.ValSizem2.value)"
											@change="model.ValSizem2.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.isVisible || controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.isVisible || controls.F_PROPERTY__PROPERTIES__ORDER.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE"
										v-on="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__BUILDINGTYPE.props"
											@update:model-value="model.ValBuildingtype.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION"
										v-on="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__DATECONSTRUCTION.props"
											:model-value="model.ValDateconstruction.value"
											@reset-icon-click="model.ValDateconstruction.fnUpdateValue(model.ValDateconstruction.originalValue ?? new Date())"
											@update:model-value="model.ValDateconstruction.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.F_PROPERTY__PROPERTIES__ORDER.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__ORDER.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTIES__ORDER"
										v-on="controls.F_PROPERTY__PROPERTIES__ORDER.handlers"
										:loading="controls.F_PROPERTY__PROPERTIES__ORDER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PROPERTY__PROPERTIES__ORDER.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__ORDER.props"
											@update:model-value="model.ValOrder.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.isVisible">
								<q-col v-if="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.isVisible">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.isVisible"
										class="i-radio-container"
										v-bind="controls.F_PROPERTY__PROPERTIES__TYPOLOGY"
										v-on="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.handlers"
										:label-position="labelAlignment.topleft"
										:loading="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-radio-group
											v-if="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.props"
											v-on="controls.F_PROPERTY__PROPERTIES__TYPOLOGY.handlers">
											<q-radio-button
												v-for="radio in controls.F_PROPERTY__PROPERTIES__TYPOLOGY.items"
												:key="radio.key"
												:label="radio.value"
												:value="radio.key" />
										</q-radio-group>
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End F_PROPERTY__PSEUD__NEWGRP03 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__NEWGRP04.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__NEWGRP04.isVisible">
						<q-group-collapsible
							v-if="controls.F_PROPERTY__PSEUD__NEWGRP04.isVisible"
							id="F_PROPERTY__PSEUD__NEWGRP04"
							v-bind="controls.F_PROPERTY__PSEUD__NEWGRP04"
							v-on="controls.F_PROPERTY__PSEUD__NEWGRP04.handlers">
							<!-- Start F_PROPERTY__PSEUD__NEWGRP04 -->
							<q-row v-if="controls.F_PROPERTY__BROKER__NAME.isVisible || controls.F_PROPERTY__BROKER__PHOTO.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__BROKER__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__BROKER__NAME.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__BROKER__NAME"
										v-on="controls.F_PROPERTY__BROKER__NAME.handlers"
										:loading="controls.F_PROPERTY__BROKER__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.F_PROPERTY__BROKER__NAME.isVisible"
											v-bind="controls.F_PROPERTY__BROKER__NAME.props"
											v-on="controls.F_PROPERTY__BROKER__NAME.handlers" />
										<q-see-more-f-property-broker-name
											v-if="controls.F_PROPERTY__BROKER__NAME.seeMoreIsVisible"
											v-bind="controls.F_PROPERTY__BROKER__NAME.seeMoreParams"
											v-on="controls.F_PROPERTY__BROKER__NAME.handlers" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.F_PROPERTY__BROKER__PHOTO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__BROKER__PHOTO.isVisible"
										class="q-image"
										v-bind="controls.F_PROPERTY__BROKER__PHOTO"
										v-on="controls.F_PROPERTY__BROKER__PHOTO.handlers"
										:loading="controls.F_PROPERTY__BROKER__PHOTO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.F_PROPERTY__BROKER__PHOTO.isVisible"
											v-bind="controls.F_PROPERTY__BROKER__PHOTO.props"
											v-on="controls.F_PROPERTY__BROKER__PHOTO.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__BROKER__EMAIL.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__BROKER__EMAIL.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__BROKER__EMAIL.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__BROKER__EMAIL"
										v-on="controls.F_PROPERTY__BROKER__EMAIL.handlers"
										:loading="controls.F_PROPERTY__BROKER__EMAIL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PROPERTY__BROKER__EMAIL.props"
											@blur="onBlur(controls.F_PROPERTY__BROKER__EMAIL, model.BrokerValEmail.value)"
											@change="model.BrokerValEmail.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End F_PROPERTY__PSEUD__NEWGRP04 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.isVisible">
						<q-table
							v-if="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.isVisible"
							v-bind="controls.F_PROPERTY__PSEUD__PROPERTY_GRID"
							v-on="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.F_PROPERTY__PSEUD__PROPERTY_GRID"
									v-on="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.handlers" />
							</template>
							<!-- USE /[MANUAL TRA CUSTOM_TABLE F_PROPERTY__PSEUD__PROPERTY_GRID]/ -->
						</q-table>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__CONTACT_GRID.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__CONTACT_GRID.isVisible">
						<q-table
							v-if="controls.F_PROPERTY__PSEUD__CONTACT_GRID.isVisible"
							v-bind="controls.F_PROPERTY__PSEUD__CONTACT_GRID"
							v-on="controls.F_PROPERTY__PSEUD__CONTACT_GRID.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.F_PROPERTY__PSEUD__CONTACT_GRID"
									v-on="controls.F_PROPERTY__PSEUD__CONTACT_GRID.handlers" />
							</template>
							<!-- USE /[MANUAL TRA CUSTOM_TABLE F_PROPERTY__PSEUD__CONTACT_GRID]/ -->
						</q-table>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormFPropertyViewModel.js'

	const requiredTextResources = ['QFormFProperty', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_INCLUDEJS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFProperty',

		components: {
			QSeeMoreFPropertyCityCity: defineAsyncComponent(() => import('@/views/forms/FormFProperty/dbedits/FPropertyCityCitySeeMore.vue')),
			QSeeMoreFPropertyBrokerName: defineAsyncComponent(() => import('@/views/forms/FormFProperty/dbedits/FPropertyBrokerNameSeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'F_PROPERTY',
					location: 'form-F_PROPERTY',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFProperty', false),

				interfaceMetadata: {
					id: 'QFormFProperty', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'F_PROPERTY',
					route: 'form-F_PROPERTY',
					area: 'PROPERTIES',
					primaryKey: 'ValCodproperties',
					designation: computed(() => this.Resources.PROPERTY43977),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					F_PROPERTY__PSEUD__NEWGRP01: new fieldControlClass.GroupControl({
						id: 'F_PROPERTY__PSEUD__NEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.MAIN_INFO34570),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['F_PROPERTY__PROPERTIES__MAIN_PHOTO', 'F_PROPERTY__PROPERTIES__SOLD', 'F_PROPERTY__PROPERTIES__TITLE', 'F_PROPERTY__PROPERTIES__PRICE', 'F_PROPERTY__PROPERTIES__DESCRIPTION'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__MAIN_PHOTO: new fieldControlClass.ImageControl({
						modelField: 'ValMain_photo',
						valueChangeEvent: 'fieldChange:properties.main_photo',
						id: 'F_PROPERTY__PROPERTIES__MAIN_PHOTO',
						name: 'MAIN_PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.MAIN_PHOTO18723),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.MAIN_PHOTO18723)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__SOLD: new fieldControlClass.BooleanControl({
						modelField: 'ValSold',
						valueChangeEvent: 'fieldChange:properties.sold',
						id: 'F_PROPERTY__PROPERTIES__SOLD',
						name: 'SOLD',
						size: 'mini',
						label: computed(() => this.Resources.SOLD56700),
						placeholder: '',
						labelPosition: computed(() => this.$app.layout.CheckboxLabelAlignment),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__TITLE: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:properties.title',
						id: 'F_PROPERTY__PROPERTIES__TITLE',
						name: 'TITLE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TITLE21885),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__PRICE: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:properties.price',
						id: 'F_PROPERTY__PROPERTIES__PRICE',
						name: 'PRICE',
						size: 'medium',
						label: computed(() => this.Resources.PRICE06900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						maxIntegers: 10,
						maxDecimals: 4,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__DESCRIPTION: new fieldControlClass.MultilineStringControl({
						modelField: 'ValDescription',
						valueChangeEvent: 'fieldChange:properties.description',
						id: 'F_PROPERTY__PROPERTIES__DESCRIPTION',
						name: 'DESCRIPTION',
						size: 'xlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						rows: 0,
						cols: 30,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PSEUD__NEWGRP02: new fieldControlClass.GroupControl({
						id: 'F_PROPERTY__PSEUD__NEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.AREA47691),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_PROPERTY__CITY__CITY', 'F_PROPERTY__COUNTRY__COUNTRY'],
						controlLimits: [
						],
					}, this),
					F_PROPERTY__CITY__CITY: new fieldControlClass.LookupControl({
						modelField: 'TableCityCity',
						valueChangeEvent: 'fieldChange:city.city',
						id: 'F_PROPERTY__CITY__CITY',
						name: 'CITY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CITY42505),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodcity_fk',
							dependencyEvent: 'fieldChange:properties.codcity_fk'
						},
						dependentFields: () => ({
							set 'city.codcity'(value) { vm.model.ValCodcity_fk.updateValue(value) },
							set 'city.city'(value) { vm.model.TableCityCity.updateValue(value) },
							set 'country.country'(value) { vm.model.CityCountryValCountry.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_PROPERTY__COUNTRY__COUNTRY: new fieldControlClass.StringControl({
						modelField: 'CityCountryValCountry',
						valueChangeEvent: 'fieldChange:country.country',
						dependentModelField: 'ValCodcountry_fk',
						dependentChangeEvent: 'fieldChange:city.codcountry_fk',
						id: 'F_PROPERTY__COUNTRY__COUNTRY',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP02',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PSEUD__NEWGRP03: new fieldControlClass.GroupControl({
						id: 'F_PROPERTY__PSEUD__NEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.DETAILS43714),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_PROPERTY__PROPERTIES__BATHROOMSNUMBER', 'F_PROPERTY__PROPERTIES__SIZEM2', 'F_PROPERTY__PROPERTIES__BUILDINGTYPE', 'F_PROPERTY__PROPERTIES__DATECONSTRUCTION', 'F_PROPERTY__PROPERTIES__ORDER', 'F_PROPERTY__PROPERTIES__TYPOLOGY'],
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__BATHROOMSNUMBER: new fieldControlClass.NumberControl({
						modelField: 'ValBathroomsnumber',
						valueChangeEvent: 'fieldChange:properties.bathroomsnumber',
						id: 'F_PROPERTY__PROPERTIES__BATHROOMSNUMBER',
						name: 'BATHROOMSNUMBER',
						size: 'medium',
						label: computed(() => this.Resources.BATHROOM_COUNT05757),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP03',
						maxIntegers: 15,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__SIZEM2: new fieldControlClass.StringControl({
						modelField: 'ValSizem2',
						valueChangeEvent: 'fieldChange:properties.sizem2',
						id: 'F_PROPERTY__PROPERTIES__SIZEM2',
						name: 'SIZEM2',
						size: 'medium',
						label: computed(() => this.Resources.SIZE10299),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP03',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__BUILDINGTYPE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValBuildingtype',
						valueChangeEvent: 'fieldChange:properties.buildingtype',
						id: 'F_PROPERTY__PROPERTIES__BUILDINGTYPE',
						name: 'BUILDINGTYPE',
						size: 'mini',
						label: computed(() => this.Resources.BUILDING_TYPE34158),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP03',
						maxLength: 1,
						arrayName: 'building_type',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__DATECONSTRUCTION: new fieldControlClass.DateControl({
						modelField: 'ValDateconstruction',
						valueChangeEvent: 'fieldChange:properties.dateconstruction',
						id: 'F_PROPERTY__PROPERTIES__DATECONSTRUCTION',
						name: 'DATECONSTRUCTION',
						size: 'medium',
						label: computed(() => this.Resources.CONSTRUCTION_DATE18132),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP03',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__ORDER: new fieldControlClass.NumberControl({
						modelField: 'ValOrder',
						valueChangeEvent: 'fieldChange:properties.order',
						id: 'F_PROPERTY__PROPERTIES__ORDER',
						name: 'ORDER',
						size: 'small',
						label: computed(() => this.Resources.ID48520),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP03',
						maxIntegers: 8,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTIES__TYPOLOGY: new fieldControlClass.RadioGroupControl({
						modelField: 'ValTypology',
						valueChangeEvent: 'fieldChange:properties.typology',
						id: 'F_PROPERTY__PROPERTIES__TYPOLOGY',
						name: 'TYPOLOGY',
						label: computed(() => this.Resources.TYPOLOGY11991),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP03',
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'typology',
						columns: 1,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PSEUD__NEWGRP04: new fieldControlClass.GroupControl({
						id: 'F_PROPERTY__PSEUD__NEWGRP04',
						name: 'NEWGRP04',
						size: 'block',
						label: computed(() => this.Resources.BROKERS_INFORMATION64793),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_PROPERTY__BROKER__NAME', 'F_PROPERTY__BROKER__PHOTO', 'F_PROPERTY__BROKER__EMAIL'],
						controlLimits: [
						],
					}, this),
					F_PROPERTY__BROKER__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableBrokerName',
						valueChangeEvent: 'fieldChange:broker.name',
						id: 'F_PROPERTY__BROKER__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.BROKERS_NAME50728),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP04',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValBroker_fk',
							dependencyEvent: 'fieldChange:properties.broker_fk'
						},
						dependentFields: () => ({
							set 'broker.codbroker'(value) { vm.model.ValBroker_fk.updateValue(value) },
							set 'broker.name'(value) { vm.model.TableBrokerName.updateValue(value) },
							set 'broker.main_photo'(value) { vm.model.BrokerValMain_photo.updateValue(value) },
							set 'broker.email'(value) { vm.model.BrokerValEmail.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_PROPERTY__BROKER__PHOTO: new fieldControlClass.ImageControl({
						modelField: 'BrokerValMain_photo',
						valueChangeEvent: 'fieldChange:broker.main_photo',
						dependentModelField: 'ValBroker_fk',
						dependentChangeEvent: 'fieldChange:properties.broker_fk',
						id: 'F_PROPERTY__BROKER__PHOTO',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP04',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__BROKER__EMAIL: new fieldControlClass.StringControl({
						modelField: 'BrokerValEmail',
						valueChangeEvent: 'fieldChange:broker.email',
						dependentModelField: 'ValBroker_fk',
						dependentChangeEvent: 'fieldChange:properties.broker_fk',
						id: 'F_PROPERTY__BROKER__EMAIL',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.EMAIL25170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP04',
						maxLength: 256,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PSEUD__PROPERTY_GRID: new fieldControlClass.TableListControl({
						id: 'F_PROPERTY__PSEUD__PROPERTY_GRID',
						name: 'PROPERTY_GRID',
						size: 'block',
						label: computed(() => this.Resources.PROPERTIES34868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROPERTIES',
						action: 'F_property_ValProperty_grid',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValMain_photo',
								area: 'PROPERTIES',
								field: 'MAIN_PHOTO',
								label: computed(() => this.Resources.MAIN_PHOTO18723),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.MAIN_PHOTO18723)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTitle',
								area: 'PROPERTIES',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValProperty_grid',
							serverMode: true,
							pkColumn: 'ValCodproperties',
							tableAlias: 'PROPERTIES',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROPERTIES34868),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CITY', 'changed-BROKER', 'changed-PROPERTIES'],
						uuid: 'F_property_ValProperty_grid',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'properties'],
								dependencyEvents: ['fieldChange:properties.codproperties'],
								dependencyField: 'PROPERTIES.CODPROPERTIES',
								fnValueSelector: (model) => model.ValCodproperties.value
							},
						],
					}, this),
					F_PROPERTY__PSEUD__CONTACT_GRID: new fieldControlClass.TableListControl({
						id: 'F_PROPERTY__PSEUD__CONTACT_GRID',
						name: 'CONTACT_GRID',
						size: 'block',
						label: computed(() => this.Resources.CONTACTS55742),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROPERTIES',
						action: 'F_property_ValContact_grid',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValClient_name',
								area: 'CONTACT',
								field: 'CLIENT_NAME',
								label: computed(() => this.Resources.CLIENT_NAME39245),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'CONTACT',
								field: 'DATE',
								label: computed(() => this.Resources.DATE18475),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValDescription',
								area: 'CONTACT',
								field: 'DESCRIPTION',
								label: computed(() => this.Resources.DESCRIPTION03846),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValContact_grid',
							serverMode: true,
							pkColumn: 'ValCodcontact',
							tableAlias: 'CONTACT',
							tableNamePlural: computed(() => this.Resources.CONTACTS55742),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CONTACTS55742),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_CONTACT',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_CONTACT',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_CONTACT',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_CONTACT',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_CONTACT',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__F_CONTACT',
								name: '_F_CONTACT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'F_CONTACT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'F_CONTACT': {
									fnKeySelector: (row) => row.Fields.ValCodcontact,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PROPERTIES', 'changed-CONTACT'],
						uuid: 'F_property_ValContact_grid',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'properties'],
								dependencyEvents: ['fieldChange:properties.codproperties'],
								dependencyField: 'PROPERTIES.CODPROPERTIES',
								fnValueSelector: (model) => model.ValCodproperties.value
							},
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'F_PROPERTY__PSEUD__NEWGRP01',
					'F_PROPERTY__PSEUD__NEWGRP02',
					'F_PROPERTY__PSEUD__NEWGRP03',
					'F_PROPERTY__PSEUD__NEWGRP04',
				]),

				tableFields: readonly([
					'F_PROPERTY__PSEUD__PROPERTY_GRID',
					'F_PROPERTY__PSEUD__CONTACT_GRID',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Broker: {
						get ValEmail() { return vm.model.BrokerValEmail.value },
						set ValEmail(value) { vm.model.BrokerValEmail.updateValue(value) },
						get ValName() { return vm.model.TableBrokerName.value },
						set ValName(value) { vm.model.TableBrokerName.updateValue(value) },
						get ValMain_photo() { return vm.model.BrokerValMain_photo.value },
						set ValMain_photo(value) { vm.model.BrokerValMain_photo.updateValue(value) },
					},
					City: {
						get ValCity() { return vm.model.TableCityCity.value },
						set ValCity(value) { vm.model.TableCityCity.updateValue(value) },
					},
					Country: {
						get ValCountry() { return vm.model.CityCountryValCountry.value },
						set ValCountry(value) { vm.model.CityCountryValCountry.updateValue(value) },
					},
					Properties: {
						get ValBathroomsnumber() { return vm.model.ValBathroomsnumber.value },
						set ValBathroomsnumber(value) { vm.model.ValBathroomsnumber.updateValue(value) },
						get ValBroker_fk() { return vm.model.ValBroker_fk.value },
						set ValBroker_fk(value) { vm.model.ValBroker_fk.updateValue(value) },
						get ValBuildingtype() { return vm.model.ValBuildingtype.value },
						set ValBuildingtype(value) { vm.model.ValBuildingtype.updateValue(value) },
						get ValCodcity_fk() { return vm.model.ValCodcity_fk.value },
						set ValCodcity_fk(value) { vm.model.ValCodcity_fk.updateValue(value) },
						get ValDateconstruction() { return vm.model.ValDateconstruction.value },
						set ValDateconstruction(value) { vm.model.ValDateconstruction.updateValue(value) },
						get ValDescription() { return vm.model.ValDescription.value },
						set ValDescription(value) { vm.model.ValDescription.updateValue(value) },
						get ValMain_photo() { return vm.model.ValMain_photo.value },
						set ValMain_photo(value) { vm.model.ValMain_photo.updateValue(value) },
						get ValOrder() { return vm.model.ValOrder.value },
						set ValOrder(value) { vm.model.ValOrder.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValSizem2() { return vm.model.ValSizem2.value },
						set ValSizem2(value) { vm.model.ValSizem2.updateValue(value) },
						get ValSold() { return vm.model.ValSold.value },
						set ValSold(value) { vm.model.ValSold.updateValue(value) },
						get ValTitle() { return vm.model.ValTitle.value },
						set ValTitle(value) { vm.model.ValTitle.updateValue(value) },
						get ValTypology() { return vm.model.ValTypology.value },
						set ValTypology(value) { vm.model.ValTypology.updateValue(value) },
					},
					keys: {
						/** The primary key of the PROPERTIES table */
						get properties() { return vm.model.ValCodproperties },
						/** The foreign key to the BROKER table */
						get broker() { return vm.model.ValBroker_fk },
						/** The foreign key to the CITY table */
						get city() { return vm.model.ValCodcity_fk },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_CODEJS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA COMPONENT_BEFORE_UNMOUNT F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_LOAD_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_LOADED_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_APPLY_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_APPLY_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_SAVE_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_SAVE_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_DEL_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_DEL_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_EXIT_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_EXIT_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA DLGUPDT F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA CTRLBLR F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA CTRLUPD F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FUNCTIONS_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
